using Erp.Data.Dto.DebitNote;
using Erp.Data.Dto.DeliveryVoucher;
using Erp.Data.Entities.AccountsModule;
using Erp.Data.Entities.PurchasesModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts;
using Erp.Infrastructure.Abstracts.AccountsModule;
using Erp.Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations
{
  public class DebitNoteService : IDebitNoteService
  {
    private readonly IDebitNoteRepository _DebitNoteRepository;
    private readonly IDebitNoteItemRepository _DebitNoteItemRepository;
    private readonly IProductService _productService;
    private readonly IWarehouseService _warehouseService;
    private readonly IJournalEntryRepository _journalEntryRepository;
    private readonly IJournalEntryDetailRepository _journalEntryDetailRepository;

    private readonly IAccountRepository<SecondaryAccount> _SecondaryAccountRepository;
    private readonly ISupplierService _supplierService;
    private readonly IDeliveryVoucherService _deliveryVoucherService;

    // Isupplair
    public DebitNoteService(IDebitNoteRepository DebitNoteRepository, IProductService productService, IWarehouseService warehouseService, IDebitNoteItemRepository DebitNoteItemRepository,
      IJournalEntryRepository journalEntryRepository,
      IJournalEntryDetailRepository journalEntryDetailRepository,
      IAccountRepository<SecondaryAccount> SecondaryAccountRepository,
      ISupplierService supplierService,
      IDeliveryVoucherService deliveryVoucherService)
    {
      _DebitNoteRepository = DebitNoteRepository;
      _DebitNoteItemRepository = DebitNoteItemRepository;
      _productService = productService;
      _warehouseService = warehouseService;
      _journalEntryRepository = journalEntryRepository;
      _journalEntryDetailRepository = journalEntryDetailRepository;
      _supplierService = supplierService;
      _SecondaryAccountRepository = SecondaryAccountRepository;
      _deliveryVoucherService = deliveryVoucherService;
    }

    public async Task<AddDeliveryVoucherRequest> CreateAddDeliveryVoucherRequestAsync(
DateTime InvoiceDate,
int SupplierId,
List<DebitNoteItem> invoiceItems,
int PurchaseReturnId)
    {
      var DeliveryVoucherRequest = new AddDeliveryVoucherRequest()
      {
        DeliveryDate = InvoiceDate,
        purchaseReturnId = PurchaseReturnId,
        DeliveryVoucherItemDT0s = invoiceItems.Select(x => new DeliveryVoucherItemDT0()
        {
          ProductId = x.ProductId,
          Quantity = x.Quantity,
          UnitPrice = x.UnitPrice,

        }).ToList()
      };

      return DeliveryVoucherRequest;
    }
    public async Task<string> AddDebitNote(AddDebitNoteRequest DebitNoteRequest)
    {
      var DebitNote = new DebitNote()
      {
        NoteDate = (DateTime)DebitNoteRequest.InvoiceDate,
        Notes = DebitNoteRequest.Notes,
        Amount = DebitNoteRequest.TotalAmount,
        SupplierId = DebitNoteRequest.SupplierId
      };


      var transact = _DebitNoteRepository.BeginTransaction();
      try
      {

        JournalEntry JournalEntry = new JournalEntry()
        {
          EntryDate = DateTime.Now,
          Description = "Purchase Debit Note #"
        };
        var NewJournalEntry = await _journalEntryRepository.AddAsync(JournalEntry);

        DebitNote.JournalEntryID = NewJournalEntry.JournalEntryID;
        DebitNote.paymentStatusId = 1;

        var newDebitNote = await _DebitNoteRepository.AddAsync(DebitNote);


        NewJournalEntry.Description += newDebitNote.DebitNoteId.ToString();
        await _journalEntryRepository.UpdateAsync(NewJournalEntry);

        decimal total = 0;

        foreach (var item in DebitNoteRequest.DebitNoteItemDT0s)
        {
          var DebitNoteItem = new DebitNoteItem()
          {
            DebitNoteId = newDebitNote.DebitNoteId,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            ProductId = item.ProductId,
            Tax = item.Tax,
            discount = item.discount,
          };
          total += item.Quantity * item.UnitPrice;

          await _DebitNoteItemRepository.AddAsync(DebitNoteItem);
        }


        var PurAccId = (await _SecondaryAccountRepository.GetTableNoTracking()
.Where(x => x.AccountName == "Purchases").SingleAsync()).AccountID;

        await _journalEntryDetailRepository.AddAsync(new JournalEntryDetail()
        {
          JournalEntryID = NewJournalEntry.JournalEntryID,
          Description = "Purchase Debit Note #" + newDebitNote.DebitNoteId.ToString(),

          AccountID = PurAccId,
          Debit = 0.00M,
          Credit = total
        });

        var supplierAccId = (await _supplierService.GetSupplierByIdAsync(newDebitNote.SupplierId)).AccountId;
        await _journalEntryDetailRepository.AddAsync(new JournalEntryDetail()
        {
          JournalEntryID = NewJournalEntry.JournalEntryID,

          Description = "Purchase Debit Note #" + newDebitNote.DebitNoteId.ToString(),

          AccountID = supplierAccId,
          Debit = total,
          Credit = 0.00M
        });



        newDebitNote.Amount = total;

        await _DebitNoteRepository.UpdateAsync(newDebitNote);

        await transact.CommitAsync();


        var DeliveryVoucherRequest = await CreateAddDeliveryVoucherRequestAsync(newDebitNote.NoteDate,
        newDebitNote.SupplierId,
      _DebitNoteItemRepository.GetTableNoTracking()
      .Where(x => x.DebitNoteId == newDebitNote.DebitNoteId).ToList(),
      newDebitNote.DebitNoteId);


        await _deliveryVoucherService.AddDeliveryVoucherAsync(DeliveryVoucherRequest, 2);
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }

    }

    public async Task<string> DeleteAsync(DebitNote DebitNote)
    {

      var transact = _DebitNoteRepository.BeginTransaction();
      try
      {
        await _DebitNoteRepository.DeleteAsync(DebitNote);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<GetDebitNoteByIdDto> GetDebitNoteByIdAsync(int id)
    {
      var DebitNote = _DebitNoteRepository.GetTableNoTracking().Where(x => x.DebitNoteId == id).Include(x => x.Supplier).Include(x => x.Items).ThenInclude(r => r.Product).SingleOrDefault();

      var dto = new GetDebitNoteByIdDto()
      {
        DebitNoteId = DebitNote.DebitNoteId,
        InvoiceDate = DebitNote.NoteDate,
        Notes = DebitNote.Notes,
        TotalAmount = DebitNote.Amount,
        SupplierId = DebitNote.SupplierId,
        JournalEntryID = DebitNote.JournalEntryID,
        DebitNoteItemsDto = new List<DebitNoteItemDto>()
      };

      dto.DebitNoteItemsDto.AddRange(DebitNote.Items.Select(x => new DebitNoteItemDto
      {
        DebitNoteItemId = x.DebitNoteItemId,
        Quantity = x.Quantity,
        UnitPrice = x.UnitPrice,
        TotalPrice = x.TotalPrice,
        ProductId = x.ProductId

      }));

      return dto;
    }

    public async Task<List<GetDebitNoteByIdDto>> GetDebitNotesListAsync()
    {
      var DebitNotes = _DebitNoteRepository.GetTableNoTracking().Include(x => x.Supplier).ToList();

      var dtoList = new List<GetDebitNoteByIdDto>();

      dtoList.AddRange(DebitNotes.Select(x => new GetDebitNoteByIdDto()
      {
        DebitNoteId = x.DebitNoteId,
        InvoiceDate = x.NoteDate,
        Notes = x.Notes,
        TotalAmount = x.Amount,
        SupplierId = x.SupplierId,
        JournalEntryID = x.JournalEntryID
      }));

      return dtoList;
    }

    public async Task<string> UpdateAsync(UpdateDebitNoteRequest DebitNoteRequest)
    {
      var DebitNote = new DebitNote()
      {
        DebitNoteId = DebitNoteRequest.DebitNoteId,
        NoteDate = DebitNoteRequest.InvoiceDate,
        Notes = DebitNoteRequest.Notes,
        SupplierId = DebitNoteRequest.SupplierId

      };


      var transact = _DebitNoteRepository.BeginTransaction();
      try
      {
        await _DebitNoteRepository.UpdateAsync(DebitNote);

        foreach (var item in DebitNoteRequest.DebitNoteItems)
        {
          var DebitNoteItem = new DebitNoteItem()
          {
            DebitNoteId = DebitNoteRequest.DebitNoteId,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            ProductId = item.ProductId
          };
          if (item.DebitNoteItemId != null)
          {
            DebitNoteItem.DebitNoteItemId = (int)item.DebitNoteItemId;
            await _DebitNoteItemRepository.UpdateAsync(DebitNoteItem);

          }
          else
          {
            await _DebitNoteItemRepository.AddAsync(DebitNoteItem);

          }

        }




        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }



    public async Task<string> DeleteByIdAsync(int id)
    {
      var DebitNote = _DebitNoteRepository.GetTableNoTracking().Where(x => x.DebitNoteId == id).SingleOrDefault();

      if (DebitNote == null)
      {
        return MessageCenter.CrudMessage.DoesNotExist;
      }
      var transact = _DebitNoteRepository.BeginTransaction();
      try
      {
        await _DebitNoteRepository.DeleteAsync(DebitNote);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }

  }
}
