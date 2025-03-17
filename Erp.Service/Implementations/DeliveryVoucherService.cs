using Erp.Data.Dto.DeliveryVoucher;
using Erp.Data.Entities.AccountsModule;
using Erp.Data.Entities.InventoryModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts;
using Erp.Infrastructure.Abstracts.AccountsModule;
using Erp.Infrastructure.Abstracts.InventoryModule;
using Erp.Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations
{
  public class DeliveryVoucherService : IDeliveryVoucherService
  {
    private readonly IDeliveryVoucherRepository _DeliveryVoucherRepository;
    private readonly IDeliveryVoucherItemRepository _DeliveryVoucherItemRepository;
    private readonly IProductService _productService;
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IAccountRepository<SecondaryAccount> _accountRepository;
    private readonly IVoucherStatusRepository _voucherStatusRepository;

    private readonly IJournalEntryRepository _journalEntryRepository;
    private readonly IJournalEntryDetailRepository _journalEntryDetailRepository;
    private readonly ISupplierService _supplierService;



    // Isupplair
    public DeliveryVoucherService(
      IDeliveryVoucherRepository DeliveryVoucherRepository,
      IProductService productService,
      IWarehouseRepository warehouseRepository,
      IDeliveryVoucherItemRepository DeliveryVoucherItemRepository,
       IAccountRepository<SecondaryAccount> accountRepository,
      IVoucherStatusRepository voucherStatusRepository,
        IJournalEntryRepository journalEntryRepository,
      IJournalEntryDetailRepository journalEntryDetailRepository,
      ISupplierService supplierService)
    {
      _DeliveryVoucherRepository = DeliveryVoucherRepository;
      _DeliveryVoucherItemRepository = DeliveryVoucherItemRepository;
      _productService = productService;
      _warehouseRepository = warehouseRepository;
      _accountRepository = accountRepository;
      _voucherStatusRepository = voucherStatusRepository;
      _journalEntryRepository = journalEntryRepository;
      _supplierService = supplierService;
      _journalEntryDetailRepository = journalEntryDetailRepository;
    }
    private async Task<int> GetDefaultSubAccountId()
    {
      var Acc = (await _accountRepository.GetTableNoTracking().
        Where(a => a.AccountName == "Other Receivables").SingleOrDefaultAsync());
      if (Acc == null)
      {
        return 0;
      }
      return Acc.AccountID;
    }
    private async Task<int> GetDefaultWarehouseId()
    {
      var warehouse = (await _warehouseRepository.GetTableNoTracking().
        Where(a => a.IsPrimary == true).SingleOrDefaultAsync());
      if (warehouse == null)
      {
        return 0;
      }
      return warehouse.WarehouseId;
    }
    private async Task AddJournalEntry(int warehouseAccId,
    int accId,
    string DeliveryVoucherId,
    int JournalEntryID,
    decimal total)
    {
      await _journalEntryDetailRepository.AddAsync(new JournalEntryDetail()
      {
        JournalEntryID = JournalEntryID,
        Description = "Outbound Requisition - Outbound Requisition #" + DeliveryVoucherId,
        AccountID = accId,
        Debit = total,
        Credit = 0.00M
      });


      await _journalEntryDetailRepository.AddAsync(new JournalEntryDetail()
      {
        JournalEntryID = JournalEntryID,

        Description = "Outbound Requisition - Outbound Requisition #" + DeliveryVoucherId,

        AccountID = warehouseAccId,
        Debit = 0.00M,
        Credit = total
      });

    }


    private async Task UpdateProductsQuantatiyAsync(int VoucherId)
    {
      var DeliveryVoucher = _DeliveryVoucherRepository.GetTableNoTracking()
        .Where(x => x.DeliveryVoucherId == VoucherId)
        .Include(x => x.deliveryVoucherItems).ThenInclude(r => r.Product).SingleOrDefault();

      foreach (var item in DeliveryVoucher.deliveryVoucherItems)
      {
        await _productService.UpdateProductQuantatiyAsync(item.ProductId, item.Quantity * -1);
      }
    }


    public async Task<string> AddDeliveryVoucherAsync(AddDeliveryVoucherRequest DeliveryVoucherRequest, int VoucherStatusId = 1)
    {
      var accId = await GetDefaultSubAccountId();
      var PrimaryWarhouseId = await GetDefaultWarehouseId();
      var DeliveryVoucher = new DeliveryVoucher()
      {
        DeliveryDate = (DateTime)DeliveryVoucherRequest.DeliveryDate,
        Notes = DeliveryVoucherRequest.Notes,
        WarehouseId = DeliveryVoucherRequest.WarehouseId is null ? PrimaryWarhouseId :
        (int)DeliveryVoucherRequest.WarehouseId,
        AccountId = DeliveryVoucherRequest.AccountId is null ? accId :
        (int)DeliveryVoucherRequest.AccountId,
        VoucherStatusId = VoucherStatusId,
        CustomerId = DeliveryVoucherRequest.CustomerId,
        purchaseReturnId = DeliveryVoucherRequest.purchaseReturnId,
        debitNoteId = DeliveryVoucherRequest.debitNoteId
      };


      var transact = _DeliveryVoucherRepository.BeginTransaction();
      try
      {
        JournalEntry JournalEntry = new JournalEntry()
        {
          EntryDate = DateTime.Now,
          Description = "Outbound Requisition - Outbound Requisition #"
        };
        var NewJournalEntry = await _journalEntryRepository.AddAsync(JournalEntry);

        DeliveryVoucher.JournalEntryID = NewJournalEntry.JournalEntryID;
        var newDeliveryVoucher = await _DeliveryVoucherRepository.AddAsync(DeliveryVoucher);

        NewJournalEntry.Description += newDeliveryVoucher.DeliveryVoucherId.ToString();
        await _journalEntryRepository.UpdateAsync(NewJournalEntry);


        decimal total = 0;
        foreach (var item in DeliveryVoucherRequest.DeliveryVoucherItemDT0s)
        {
          var DeliveryVoucherItem = new DeliveryVoucherItem()
          {
            deliveryVoucherId = newDeliveryVoucher.DeliveryVoucherId,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            ProductId = item.ProductId
          };
          total += item.Quantity * item.UnitPrice;

          await _DeliveryVoucherItemRepository.AddAsync(DeliveryVoucherItem);
        }

        var PurAccId = accId;



        var warehouseAccId = (await _warehouseRepository.GetByIdAsync(newDeliveryVoucher.WarehouseId)).AccountId;


        if (VoucherStatusId == 1)
        {
          await AddJournalEntry(
            warehouseAccId,
            PurAccId,
            newDeliveryVoucher.DeliveryVoucherId.ToString(),
            NewJournalEntry.JournalEntryID,
          total);

          await UpdateProductsQuantatiyAsync(newDeliveryVoucher.DeliveryVoucherId);


        }


        await _DeliveryVoucherRepository.UpdateAsync(newDeliveryVoucher);



        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }

    }

    public async Task<string> DeleteAsync(DeliveryVoucher DeliveryVoucher)
    {

      var transact = _DeliveryVoucherRepository.BeginTransaction();
      try
      {
        await _DeliveryVoucherRepository.DeleteAsync(DeliveryVoucher);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<GetDeliveryVoucherByIdDto> GetDeliveryVoucherByIdAsync(int id)
    {
      var DeliveryVoucher = _DeliveryVoucherRepository.GetTableNoTracking()
        .Where(x => x.DeliveryVoucherId == id)
        .Include(x => x.Warehouse)
        .Include(x => x.Account)
        .Include(x => x.VoucherStatus)
        .Include(x => x.deliveryVoucherItems).ThenInclude(r => r.Product).SingleOrDefault();

      var dto = new GetDeliveryVoucherByIdDto()
      {
        DeliveryVoucherId = DeliveryVoucher.DeliveryVoucherId,
        DeliveryDate = DeliveryVoucher.DeliveryDate,
        Notes = DeliveryVoucher.Notes,
        Warehouse = DeliveryVoucher.Warehouse,
        Account = DeliveryVoucher.Account,
        VoucherStatus = DeliveryVoucher.VoucherStatus,
        JournalEntryID = DeliveryVoucher.JournalEntryID,
        purchaseReturnId = DeliveryVoucher.purchaseReturnId,
        debitNoteId = DeliveryVoucher.debitNoteId,
        deliveryVoucherItemDto = new List<DeliveryVoucherItemDto>()
      };

      dto.deliveryVoucherItemDto.AddRange(DeliveryVoucher.deliveryVoucherItems.Select(x => new DeliveryVoucherItemDto
      {
        DeliveryVoucherItemId = x.DeliveryVoucherItemId,
        Quantity = x.Quantity,
        UnitPrice = x.UnitPrice,
        TotalPrice = x.TotalPrice,
        Product = x.Product

      }));

      return dto;
    }

    public async Task<List<GetDeliveryVoucherByIdDto>> GetDeliveryVouchersListAsync()
    {
      var DeliveryVouchers = _DeliveryVoucherRepository
        .GetTableNoTracking()
        .Include(x => x.Warehouse)
        .Include(x => x.Account)
        .Include(x => x.VoucherStatus).ToList();

      var dtoList = new List<GetDeliveryVoucherByIdDto>();

      dtoList.AddRange(DeliveryVouchers.Select(x => new GetDeliveryVoucherByIdDto()
      {
        DeliveryVoucherId = x.DeliveryVoucherId,
        DeliveryDate = x.DeliveryDate,
        Notes = x.Notes,
        Warehouse = x.Warehouse,
        Account = x.Account,
        VoucherStatus = x.VoucherStatus,
        JournalEntryID = x.JournalEntryID,
        purchaseReturnId = x.purchaseReturnId,
        debitNoteId = x.debitNoteId
      }));

      return dtoList;
    }

    public async Task<string> UpdateAsync(UpdateDeliveryVoucherRequest DeliveryVoucherRequest)
    {
      var DeliveryVoucher = await _DeliveryVoucherRepository.GetTableAsTracking()
       .Where(x => x.DeliveryVoucherId == DeliveryVoucherRequest.DeliveryVoucherId)
       .FirstOrDefaultAsync();

      if (DeliveryVoucher == null)
      {
        return MessageCenter.CrudMessage.DoesNotExist;
      }


      DeliveryVoucher.DeliveryDate = DeliveryVoucherRequest.DeliveryDate;
      DeliveryVoucher.Notes = DeliveryVoucherRequest.Notes;
      DeliveryVoucher.WarehouseId = DeliveryVoucherRequest.WarehouseId;
      DeliveryVoucher.AccountId = DeliveryVoucherRequest.AccountId;


      var transact = _DeliveryVoucherRepository.BeginTransaction();
      try
      {
        await _DeliveryVoucherRepository.UpdateAsync(DeliveryVoucher);

        foreach (var item in DeliveryVoucherRequest.DeliveryVoucherItems)
        {
          var DeliveryVoucherItem = new DeliveryVoucherItem()
          {
            deliveryVoucherId = DeliveryVoucherRequest.DeliveryVoucherId,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            ProductId = item.ProductId
          };
          if (item.DeliveryVoucherItemId != null)
          {
            DeliveryVoucherItem.DeliveryVoucherItemId = (int)item.DeliveryVoucherItemId;
            await _DeliveryVoucherItemRepository.UpdateAsync(DeliveryVoucherItem);

          }
          else
          {
            await _DeliveryVoucherItemRepository.AddAsync(DeliveryVoucherItem);

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
      var DeliveryVoucher = _DeliveryVoucherRepository.GetTableNoTracking().Where(x => x.DeliveryVoucherId == id).SingleOrDefault();

      if (DeliveryVoucher == null)
      {
        return MessageCenter.CrudMessage.DoesNotExist;
      }
      var transact = _DeliveryVoucherRepository.BeginTransaction();
      try
      {
        await _DeliveryVoucherRepository.DeleteAsync(DeliveryVoucher);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<string> ConfirmDeliveryVoucherAsync(int DeliveryVoucherId)
    {
      var transact = _DeliveryVoucherRepository.BeginTransaction();
      try
      {

        var DeliveryVoucher = await _DeliveryVoucherRepository
          .GetTableAsTracking()
          .Where(x => x.DeliveryVoucherId == DeliveryVoucherId).Include(x => x.deliveryVoucherItems).FirstOrDefaultAsync();



        decimal total = 0;

        foreach (var item in DeliveryVoucher.deliveryVoucherItems)
        {
          total += item.Quantity * item.UnitPrice;

        }

        var PurAccId = await GetDefaultSubAccountId();



        var warehouseAccId = (await _warehouseRepository.GetByIdAsync(DeliveryVoucher.WarehouseId)).AccountId;



        await AddJournalEntry(
          warehouseAccId,
          PurAccId,
          DeliveryVoucher.DeliveryVoucherId.ToString(),
          DeliveryVoucher.JournalEntryID,
          total);

        await UpdateProductsQuantatiyAsync(DeliveryVoucher.DeliveryVoucherId);


        DeliveryVoucher.VoucherStatusId = 1;
        await _DeliveryVoucherRepository.UpdateAsync(DeliveryVoucher);


        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<string> RejectDeliveryVoucherAsync(int DeliveryVoucherId)
    {
      var transact = _DeliveryVoucherRepository.BeginTransaction();
      try
      {

        var DeliveryVoucher = await _DeliveryVoucherRepository.GetByIdAsync(DeliveryVoucherId);


        //var journalEntity = await _journalEntryRepository.GetByIdAsync(ReceivingVoucher.JournalEntryID);
        //await _journalEntryRepository.DeleteAsync(journalEntity);
        //Cant delete becuse the journalEntity is Required in ReceivingVoucher
        DeliveryVoucher.VoucherStatusId = 3;
        await _DeliveryVoucherRepository.UpdateAsync(DeliveryVoucher);


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
