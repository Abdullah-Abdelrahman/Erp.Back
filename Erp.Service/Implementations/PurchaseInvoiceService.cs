using Erp.Data.Dto.PurchaseInvoice;
using Erp.Data.Dto.ReceivingVoucher;
using Erp.Data.Entities.AccountsModule;
using Erp.Data.Entities.PurchasesModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts;
using Erp.Infrastructure.Abstracts.AccountsModule;
using Erp.Infrastructure.Abstracts.Finance;
using Erp.Service.Abstracts;
using Erp.Service.Abstracts.CommonUse;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Erp.Service.Implementations
{
  public class PurchaseInvoiceService : IPurchaseInvoiceService
  {
    private readonly IPurchaseInvoiceRepository _PurchaseInvoiceRepository;
    private readonly IPurchaseInvoiceItemRepository _PurchaseInvoiceItemRepository;
    private readonly IProductService _productService;
    private readonly IWarehouseService _warehouseService;
    private readonly IJournalEntryRepository _journalEntryRepository;
    private readonly IJournalEntryDetailRepository _journalEntryDetailRepository;
    private readonly IAccountRepository<SecondaryAccount> _SecondaryAccountRepository;
    private readonly ISupplierService _supplierService;
    private readonly IReceivingVoucherService _receivingVoucherService;


    private readonly IPaymentService _paymentService;

    private readonly ITreasuryRepository _treasuryRepository;

    private readonly IHttpContextAccessor _httpContextAccessor;
    public PurchaseInvoiceService(
      IPurchaseInvoiceRepository PurchaseInvoiceRepository,
      IProductService productService,
      IWarehouseService warehouseService,
      IPurchaseInvoiceItemRepository PurchaseInvoiceItemRepository,
      IJournalEntryRepository journalEntryRepository,
      IJournalEntryDetailRepository journalEntryDetailRepository,
      IAccountRepository<SecondaryAccount> SecondaryAccountRepository,
      ISupplierService supplierService,
      IReceivingVoucherService receivingVoucherService,
      IPaymentService paymentService,
      ITreasuryRepository treasuryRepository,
      IHttpContextAccessor httpContextAccessor)
    {
      _PurchaseInvoiceRepository = PurchaseInvoiceRepository;
      _PurchaseInvoiceItemRepository = PurchaseInvoiceItemRepository;
      _productService = productService;
      _warehouseService = warehouseService;

      _SecondaryAccountRepository = SecondaryAccountRepository;
      _supplierService = supplierService;
      _journalEntryRepository = journalEntryRepository;
      _journalEntryDetailRepository = journalEntryDetailRepository;
      _receivingVoucherService = receivingVoucherService;


      _paymentService = paymentService;
      _treasuryRepository = treasuryRepository;
      _httpContextAccessor = httpContextAccessor;
    }

    public async Task<AddReceivingVoucherRequest> CreateAddReceivingVoucherRequestAsync(
      DateTime InvoiceDate,
      int SupplierId,
      List<PurchaseInvoiceItem> invoiceItems,
      int PurchaseInvoiceId)
    {
      var ReceivingVoucherRequest = new AddReceivingVoucherRequest()
      {
        ReceivingDate = InvoiceDate,
        SupplierId = SupplierId,
        purchaseInvoiceId = PurchaseInvoiceId,
        receivingVoucherItemDT0s = invoiceItems.Select(x => new ReceivingVoucherItemDT0()
        {
          ProductId = x.ProductId,
          Quantity = x.Quantity,
          UnitPrice = x.UnitPrice,

        }).ToList()
      };

      return ReceivingVoucherRequest;
    }


    public async Task CreateSupplierPaymentAsync(bool AlreadyPaid,
      int SupplierId, int PInvoiceId, decimal Total, decimal amount = 0)
    {
      var MainTreasuryId = (await _treasuryRepository.GetTableNoTracking().FirstAsync()).Id;
      var user = _httpContextAccessor.HttpContext?.User;
      var userId = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

      var SupplierPayment = new SupplierPayment()
      {
        Amount = amount,
        CreatedDate = DateTime.Now,
        AddedById = userId,
        treasuryId = MainTreasuryId,
        Currency = "",
        SupplierId = SupplierId,
        PurchaseInvoiceId = PInvoiceId
      };
      if (AlreadyPaid == true)
      {
        SupplierPayment.Amount = Total;
      }


      await _paymentService.AddSupplierPaymentAsync(SupplierPayment);

    }

    public async Task<string> AddPurchaseInvoice(AddPurchaseInvoiceRequest PurchaseInvoiceRequest)
    {
      var PurchaseInvoice = new PurchaseInvoice()
      {
        InvoiceDate = (DateTime)PurchaseInvoiceRequest.InvoiceDate,
        Notes = PurchaseInvoiceRequest.Notes,
        TotalAmount = PurchaseInvoiceRequest.TotalAmount,
        SupplierId = PurchaseInvoiceRequest.SupplierId
      };


      var transact = _PurchaseInvoiceRepository.BeginTransaction();
      try
      {
        JournalEntry JournalEntry = new JournalEntry()
        {
          EntryDate = DateTime.Now,
          Description = "Purchase Invoice #"
        };
        var NewJournalEntry = await _journalEntryRepository.AddAsync(JournalEntry);

        PurchaseInvoice.JournalEntryID = NewJournalEntry.JournalEntryID;
        //Add Purchase Payment Status

        if (PurchaseInvoiceRequest.AlreadyPaid == true)
        {
          PurchaseInvoice.paymentStatusId = 1;


        }
        else if (PurchaseInvoiceRequest.AmountPaid > 0)
        {
          PurchaseInvoice.paymentStatusId = 2;

        }
        else
        {
          PurchaseInvoice.paymentStatusId = 3;

        }


        var newPurchaseInvoice = await _PurchaseInvoiceRepository.AddAsync(PurchaseInvoice);



        NewJournalEntry.Description += newPurchaseInvoice.PurchaseInvoiceId.ToString();
        await _journalEntryRepository.UpdateAsync(NewJournalEntry);


        decimal total = 0;
        foreach (var item in PurchaseInvoiceRequest.PurchaseInvoiceItemDT0s)
        {
          var PurchaseInvoiceItem = new PurchaseInvoiceItem()
          {
            PurchaseInvoiceId = newPurchaseInvoice.PurchaseInvoiceId,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            ProductId = item.ProductId,
            Tax = item.Tax,
            discount = item.discount,
          };
          total += item.Quantity * item.UnitPrice;

          await _PurchaseInvoiceItemRepository.AddAsync(PurchaseInvoiceItem);
        }

        var PurAccId = (await _SecondaryAccountRepository.GetTableNoTracking()
          .Where(x => x.AccountName == "Purchases").SingleAsync()).AccountID;
        await _journalEntryDetailRepository.AddAsync(new JournalEntryDetail()
        {
          JournalEntryID = NewJournalEntry.JournalEntryID,
          Description = "Purchase Invoice #" + newPurchaseInvoice.PurchaseInvoiceId.ToString(),

          AccountID = PurAccId,
          Debit = total,
          Credit = 0.00M
        });

        var supplierAccId = (await _supplierService.GetSupplierByIdAsync(newPurchaseInvoice.SupplierId)).AccountId;
        await _journalEntryDetailRepository.AddAsync(new JournalEntryDetail()
        {
          JournalEntryID = NewJournalEntry.JournalEntryID,

          Description = "Purchase Invoice #" + newPurchaseInvoice.PurchaseInvoiceId.ToString(),

          AccountID = supplierAccId,
          Debit = 0.00M,
          Credit = total
        });



        newPurchaseInvoice.TotalAmount = total;

        await _PurchaseInvoiceRepository.UpdateAsync(newPurchaseInvoice);


        await transact.CommitAsync();


        var ReceivingVoucherRequest = await CreateAddReceivingVoucherRequestAsync(newPurchaseInvoice.InvoiceDate,
          newPurchaseInvoice.SupplierId,
          _PurchaseInvoiceItemRepository.GetTableNoTracking()
          .Where(x => x.PurchaseInvoiceId == newPurchaseInvoice.PurchaseInvoiceId).ToList(),
          newPurchaseInvoice.PurchaseInvoiceId);


        await _receivingVoucherService.AddReceivingVoucherAsync(ReceivingVoucherRequest, 2);

        await CreateSupplierPaymentAsync(PurchaseInvoiceRequest.AlreadyPaid, PurchaseInvoiceRequest.SupplierId, newPurchaseInvoice.PurchaseInvoiceId, total, PurchaseInvoiceRequest.AmountPaid);


        return MessageCenter.CrudMessage.Success;

      }
      catch (Exception ex)
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied + ex.Message;
      }




    }

    public async Task<string> DeleteAsync(PurchaseInvoice PurchaseInvoice)
    {

      var transact = _PurchaseInvoiceRepository.BeginTransaction();
      try
      {
        await _PurchaseInvoiceRepository.DeleteAsync(PurchaseInvoice);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<GetPurchaseInvoiceByIdDto> GetPurchaseInvoiceByIdAsync(int id)
    {
      var PurchaseInvoice = _PurchaseInvoiceRepository.GetTableNoTracking().Where(x => x.PurchaseInvoiceId == id)
        .Include(x => x.Supplier)
        .Include(x => x.paymentStatus)
        .Include(x => x.payments)
        .Include(x => x.Items).ThenInclude(r => r.Product).SingleOrDefault();

      if (PurchaseInvoice == null)
      {
        return new GetPurchaseInvoiceByIdDto();
      }

      var dto = new GetPurchaseInvoiceByIdDto()
      {
        PurchaseInvoiceId = PurchaseInvoice.PurchaseInvoiceId,
        InvoiceDate = PurchaseInvoice.InvoiceDate,
        Notes = PurchaseInvoice.Notes,
        TotalAmount = PurchaseInvoice.TotalAmount,
        SupplierId = PurchaseInvoice.SupplierId,
        JournalEntryID = PurchaseInvoice.JournalEntryID,
        paymentStatus = PurchaseInvoice.paymentStatus.Name,
        PurchaseInvoiceItemsDto = new List<PurchaseInvoiceItemDto>()
      };

      dto.PurchaseInvoiceItemsDto.AddRange(PurchaseInvoice.Items.Select(x => new PurchaseInvoiceItemDto
      {
        PurchaseInvoiceItemId = x.PurchaseInvoiceItemId,
        Quantity = x.Quantity,
        UnitPrice = x.UnitPrice,
        TotalPrice = x.TotalPrice,
        ProductId = x.ProductId

      }));
      dto.supplierPaymentDtos.AddRange(PurchaseInvoice.payments.Select(x => new SupplierPaymentDto
      {
        Id = x.Id,
        Amount = x.Amount,
        SupplierName = PurchaseInvoice.Supplier.SupplierName,
        PaymentMethod = x.PaymentMethod,
        CreatedDate = x.CreatedDate

      }));
      return dto;
    }

    public async Task<List<GetPurchaseInvoiceByIdDto>> GetPurchaseInvoicesListAsync()
    {
      var PurchaseInvoices = _PurchaseInvoiceRepository.GetTableNoTracking().Include(x => x.Supplier).Include(x => x.paymentStatus).ToList();

      var dtoList = new List<GetPurchaseInvoiceByIdDto>();

      dtoList.AddRange(PurchaseInvoices.Select(x => new GetPurchaseInvoiceByIdDto()
      {
        PurchaseInvoiceId = x.PurchaseInvoiceId,
        InvoiceDate = x.InvoiceDate,
        Notes = x.Notes,
        TotalAmount = x.TotalAmount,
        SupplierId = x.SupplierId,
        JournalEntryID = x.JournalEntryID,
        paymentStatus = x.paymentStatus.Name

      }));

      return dtoList;
    }

    public async Task<string> UpdateAsync(UpdatePurchaseInvoiceRequest PurchaseInvoiceRequest)
    {
      var PurchaseInvoice = new PurchaseInvoice()
      {
        PurchaseInvoiceId = PurchaseInvoiceRequest.PurchaseInvoiceId,
        InvoiceDate = PurchaseInvoiceRequest.InvoiceDate,
        Notes = PurchaseInvoiceRequest.Notes,
        SupplierId = PurchaseInvoiceRequest.SupplierId

      };


      var transact = _PurchaseInvoiceRepository.BeginTransaction();
      try
      {
        await _PurchaseInvoiceRepository.UpdateAsync(PurchaseInvoice);

        foreach (var item in PurchaseInvoiceRequest.PurchaseInvoiceItems)
        {
          var PurchaseInvoiceItem = new PurchaseInvoiceItem()
          {
            PurchaseInvoiceId = PurchaseInvoiceRequest.PurchaseInvoiceId,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            ProductId = item.ProductId
          };
          if (item.PurchaseInvoiceItemId != null)
          {
            PurchaseInvoiceItem.PurchaseInvoiceItemId = (int)item.PurchaseInvoiceItemId;
            await _PurchaseInvoiceItemRepository.UpdateAsync(PurchaseInvoiceItem);

          }
          else
          {
            await _PurchaseInvoiceItemRepository.AddAsync(PurchaseInvoiceItem);

          }
        }




        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch (Exception ex)
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied + ex.Message;
      }
    }



    public async Task<string> DeleteByIdAsync(int id)
    {
      var PurchaseInvoice = _PurchaseInvoiceRepository.GetTableNoTracking().Where(x => x.PurchaseInvoiceId == id).SingleOrDefault();

      if (PurchaseInvoice == null)
      {
        return MessageCenter.CrudMessage.DoesNotExist;
      }
      var transact = _PurchaseInvoiceRepository.BeginTransaction();
      try
      {
        await _PurchaseInvoiceRepository.DeleteAsync(PurchaseInvoice);

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
