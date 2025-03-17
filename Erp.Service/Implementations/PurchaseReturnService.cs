using Erp.Data.Dto.DeliveryVoucher;
using Erp.Data.Dto.PurchaseInvoice;
using Erp.Data.Dto.PurchaseReturn;
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
  public class PurchaseReturnService : IPurchaseReturnService
  {
    private readonly IPurchaseReturnRepository _PurchaseReturnRepository;
    private readonly IPurchaseReturnItemRepository _PurchaseReturnItemRepository;
    private readonly IProductService _productService;
    private readonly IWarehouseService _warehouseService;
    private readonly IJournalEntryRepository _journalEntryRepository;
    private readonly IJournalEntryDetailRepository _journalEntryDetailRepository;

    private readonly IAccountRepository<SecondaryAccount> _SecondaryAccountRepository;
    private readonly ISupplierService _supplierService;
    private readonly IDeliveryVoucherService _deliveryVoucherService;


    private readonly IPaymentService _paymentService;

    private readonly ITreasuryRepository _treasuryRepository;

    private readonly IHttpContextAccessor _httpContextAccessor;
    // Isupplair
    public PurchaseReturnService(IPurchaseReturnRepository PurchaseReturnRepository, IProductService productService, IWarehouseService warehouseService, IPurchaseReturnItemRepository PurchaseReturnItemRepository,
      IJournalEntryRepository journalEntryRepository,
      IJournalEntryDetailRepository journalEntryDetailRepository,
      IAccountRepository<SecondaryAccount> SecondaryAccountRepository,
      ISupplierService supplierService,
      IDeliveryVoucherService deliveryVoucherService,
      IPaymentService paymentService,
      ITreasuryRepository treasuryRepository,
      IHttpContextAccessor httpContextAccessor)
    {
      _PurchaseReturnRepository = PurchaseReturnRepository;
      _PurchaseReturnItemRepository = PurchaseReturnItemRepository;
      _productService = productService;
      _warehouseService = warehouseService;
      _journalEntryRepository = journalEntryRepository;
      _journalEntryDetailRepository = journalEntryDetailRepository;
      _supplierService = supplierService;
      _SecondaryAccountRepository = SecondaryAccountRepository;
      _deliveryVoucherService = deliveryVoucherService;

      _paymentService = paymentService;
      _treasuryRepository = treasuryRepository;
      _httpContextAccessor = httpContextAccessor;
    }

    public async Task<AddDeliveryVoucherRequest> CreateAddDeliveryVoucherRequestAsync(
    DateTime InvoiceDate,
    int SupplierId,
    List<PurchaseReturnItem> invoiceItems, int PurchaseReturnId)
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

    public async Task CreateSupplierPaymentAsync(bool AlreadyPaid,
    int SupplierId, int PRInvoiceId, decimal Total, decimal amount = 0)
    {
      var MainTreasuryId = (await _treasuryRepository.GetTableNoTracking().FirstAsync()).Id;
      var user = _httpContextAccessor.HttpContext?.User;
      var userId = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

      if (AlreadyPaid == true)
      {
        amount = Total;
      }
      var SupplierPayment = new SupplierPayment()
      {
        Amount = -amount,
        CreatedDate = DateTime.Now,
        AddedById = userId,
        treasuryId = MainTreasuryId,
        Currency = "",
        SupplierId = SupplierId,
        PurchaseReturnId = PRInvoiceId
      };



      await _paymentService.AddSupplierPaymentAsync(SupplierPayment);

    }
    public async Task<string> AddPurchaseReturn(AddPurchaseReturnRequest PurchaseReturnRequest)
    {
      var PurchaseReturn = new PurchaseReturn()
      {
        ReturnDate = (DateTime)PurchaseReturnRequest.InvoiceDate,
        Notes = PurchaseReturnRequest.Notes,
        TotalAmount = PurchaseReturnRequest.TotalAmount,
        supplierId = PurchaseReturnRequest.SupplierId
      };


      var transact = _PurchaseReturnRepository.BeginTransaction();
      try
      {
        JournalEntry JournalEntry = new JournalEntry()
        {
          EntryDate = DateTime.Now,
          Description = "Purchase Refund #"
        };
        var NewJournalEntry = await _journalEntryRepository.AddAsync(JournalEntry);

        PurchaseReturn.JournalEntryID = NewJournalEntry.JournalEntryID;
        //Add PurchaseReturn Payment Status
        if (PurchaseReturnRequest.AlreadyPaid == true)
        {
          PurchaseReturn.paymentStatusId = 1;


        }
        else if (PurchaseReturnRequest.AmountPaid > 0)
        {
          PurchaseReturn.paymentStatusId = 2;

        }
        else
        {
          PurchaseReturn.paymentStatusId = 3;

        }

        var newPurchaseReturn = await _PurchaseReturnRepository.AddAsync(PurchaseReturn);

        NewJournalEntry.Description += newPurchaseReturn.PurchaseReturnId.ToString();
        await _journalEntryRepository.UpdateAsync(NewJournalEntry);



        decimal total = 0;

        foreach (var item in PurchaseReturnRequest.PurchaseReturnItemDT0s)
        {
          var PurchaseReturnItem = new PurchaseReturnItem()
          {
            PurchaseReturnId = newPurchaseReturn.PurchaseReturnId,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            ProductId = item.ProductId,
            Tax = item.Tax,
            discount = item.discount,
          };
          total += item.Quantity * item.UnitPrice;

          await _PurchaseReturnItemRepository.AddAsync(PurchaseReturnItem);
        }

        var PurAccId = (await _SecondaryAccountRepository.GetTableNoTracking()
     .Where(x => x.AccountName == "Purchases").SingleAsync()).AccountID;

        await _journalEntryDetailRepository.AddAsync(new JournalEntryDetail()
        {
          JournalEntryID = NewJournalEntry.JournalEntryID,
          Description = "Purchase Refund #" + newPurchaseReturn.PurchaseReturnId.ToString(),

          AccountID = PurAccId,
          Debit = 0.00M,
          Credit = total
        });

        var supplierAccId = (await _supplierService.GetSupplierByIdAsync(newPurchaseReturn.supplierId)).AccountId;
        await _journalEntryDetailRepository.AddAsync(new JournalEntryDetail()
        {
          JournalEntryID = NewJournalEntry.JournalEntryID,

          Description = "Purchase Refund #" + newPurchaseReturn.PurchaseReturnId.ToString(),

          AccountID = supplierAccId,
          Debit = total,
          Credit = 0.00M
        });



        newPurchaseReturn.TotalAmount = total;

        await _PurchaseReturnRepository.UpdateAsync(newPurchaseReturn);


        await transact.CommitAsync();

        var ReceivingVoucherRequest = await CreateAddDeliveryVoucherRequestAsync(newPurchaseReturn.ReturnDate,
        newPurchaseReturn.supplierId,
         _PurchaseReturnItemRepository.GetTableNoTracking()
         .Where(x => x.PurchaseReturnId == newPurchaseReturn.PurchaseReturnId).ToList(),
         newPurchaseReturn.PurchaseReturnId);


        await _deliveryVoucherService.AddDeliveryVoucherAsync(ReceivingVoucherRequest, 2);



        await CreateSupplierPaymentAsync(PurchaseReturnRequest.AlreadyPaid, PurchaseReturnRequest.SupplierId, newPurchaseReturn.PurchaseReturnId, total, PurchaseReturnRequest.AmountPaid);

        return MessageCenter.CrudMessage.Success;

      }
      catch (Exception ex)
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied + ex.Message;
      }

    }

    public async Task<string> DeleteAsync(PurchaseReturn PurchaseReturn)
    {

      var transact = _PurchaseReturnRepository.BeginTransaction();
      try
      {
        await _PurchaseReturnRepository.DeleteAsync(PurchaseReturn);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<GetPurchaseReturnByIdDto> GetPurchaseReturnByIdAsync(int id)
    {
      var PurchaseReturn = _PurchaseReturnRepository.GetTableNoTracking()
        .Where(x => x.PurchaseReturnId == id)
        .Include(x => x.supplier)
        .Include(x => x.paymentStatus)
        .Include(x => x.payments)
        .Include(x => x.Items).ThenInclude(r => r.Product).SingleOrDefault();

      var dto = new GetPurchaseReturnByIdDto()
      {
        PurchaseReturnId = PurchaseReturn.PurchaseReturnId,
        InvoiceDate = PurchaseReturn.ReturnDate,
        Notes = PurchaseReturn.Notes,
        TotalAmount = PurchaseReturn.TotalAmount,
        SupplierId = PurchaseReturn.supplierId,
        JournalEntryID = PurchaseReturn.JournalEntryID,
        paymentStatus = PurchaseReturn.paymentStatus.Name,
        PurchaseReturnItemsDto = new List<PurchaseReturnItemDto>()
      };

      dto.PurchaseReturnItemsDto.AddRange(PurchaseReturn.Items.Select(x => new PurchaseReturnItemDto
      {
        PurchaseReturnItemId = x.PurchaseReturnItemId,
        Quantity = x.Quantity,
        UnitPrice = x.UnitPrice,
        TotalPrice = x.TotalPrice,
        ProductId = x.ProductId

      }));
      dto.supplierPaymentDtos.AddRange(PurchaseReturn.payments.Select(x => new SupplierPaymentDto
      {
        Id = x.Id,
        Amount = x.Amount,
        SupplierName = PurchaseReturn.supplier.SupplierName,
        PaymentMethod = x.PaymentMethod,
        CreatedDate = x.CreatedDate

      }));
      return dto;
    }

    public async Task<List<GetPurchaseReturnByIdDto>> GetPurchaseReturnsListAsync()
    {
      var PurchaseReturns = _PurchaseReturnRepository.GetTableNoTracking().Include(x => x.supplier).Include(x => x.paymentStatus).ToList();

      var dtoList = new List<GetPurchaseReturnByIdDto>();

      dtoList.AddRange(PurchaseReturns.Select(x => new GetPurchaseReturnByIdDto()
      {
        PurchaseReturnId = x.PurchaseReturnId,
        InvoiceDate = x.ReturnDate,
        Notes = x.Notes,
        TotalAmount = x.TotalAmount,
        SupplierId = x.supplierId,
        JournalEntryID = x.JournalEntryID,


      }));

      return dtoList;
    }

    public async Task<string> UpdateAsync(UpdatePurchaseReturnRequest PurchaseReturnRequest)
    {
      var PurchaseReturn = new PurchaseReturn()
      {
        PurchaseReturnId = PurchaseReturnRequest.PurchaseReturnId,
        ReturnDate = PurchaseReturnRequest.InvoiceDate,
        Notes = PurchaseReturnRequest.Notes,
        supplierId = PurchaseReturnRequest.SupplierId

      };


      var transact = _PurchaseReturnRepository.BeginTransaction();
      try
      {
        await _PurchaseReturnRepository.UpdateAsync(PurchaseReturn);

        foreach (var item in PurchaseReturnRequest.PurchaseReturnItems)
        {
          var PurchaseReturnItem = new PurchaseReturnItem()
          {
            PurchaseReturnId = PurchaseReturnRequest.PurchaseReturnId,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            ProductId = item.ProductId
          };
          if (item.PurchaseReturnItemId != null)
          {
            PurchaseReturnItem.PurchaseReturnItemId = (int)item.PurchaseReturnItemId;
            await _PurchaseReturnItemRepository.UpdateAsync(PurchaseReturnItem);

          }
          else
          {
            await _PurchaseReturnItemRepository.AddAsync(PurchaseReturnItem);

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
      var PurchaseReturn = _PurchaseReturnRepository.GetTableNoTracking().Where(x => x.PurchaseReturnId == id).SingleOrDefault();

      if (PurchaseReturn == null)
      {
        return MessageCenter.CrudMessage.DoesNotExist;
      }
      var transact = _PurchaseReturnRepository.BeginTransaction();
      try
      {
        await _PurchaseReturnRepository.DeleteAsync(PurchaseReturn);

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
