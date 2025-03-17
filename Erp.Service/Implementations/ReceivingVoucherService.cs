using Erp.Data.Dto.ReceivingVoucher;
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
  public class ReceivingVoucherService : IReceivingVoucherService
  {
    private readonly IReceivingVoucherRepository _receivingVoucherRepository;
    private readonly IReceivingVoucherItemRepository _receivingVoucherItemRepository;
    private readonly IProductService _productService;
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IAccountRepository<SecondaryAccount> _accountRepository;
    private readonly IVoucherStatusRepository _voucherStatusRepository;

    private readonly IJournalEntryRepository _journalEntryRepository;
    private readonly IJournalEntryDetailRepository _journalEntryDetailRepository;
    private readonly ISupplierService _supplierService;


    // Isupplair
    public ReceivingVoucherService(
      IReceivingVoucherRepository receivingVoucherRepository,
      IProductService productService,
      IWarehouseRepository warehouseRepository,
      IReceivingVoucherItemRepository receivingVoucherItemRepository,
      IAccountRepository<SecondaryAccount> accountRepository,
      IVoucherStatusRepository voucherStatusRepository,
        IJournalEntryRepository journalEntryRepository,
      IJournalEntryDetailRepository journalEntryDetailRepository,
      ISupplierService supplierService)
    {
      _receivingVoucherRepository = receivingVoucherRepository;
      _receivingVoucherItemRepository = receivingVoucherItemRepository;
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
        Where(a => a.AccountName == "Other Payables").SingleOrDefaultAsync());
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
      string ReceivingVoucherId,
      int JournalEntryID,
      decimal total)
    {
      await _journalEntryDetailRepository.AddAsync(new JournalEntryDetail()
      {
        JournalEntryID = JournalEntryID,
        Description = "Inbound Requisition - Inbound Requisition #" + ReceivingVoucherId,
        AccountID = accId,
        Debit = 0.00M,
        Credit = total
      });


      await _journalEntryDetailRepository.AddAsync(new JournalEntryDetail()
      {
        JournalEntryID = JournalEntryID,

        Description = "Inbound Requisition - Inbound Requisition #" + ReceivingVoucherId,

        AccountID = warehouseAccId,
        Debit = total,
        Credit = 0.00M
      });

    }

    private async Task UpdateProductsQuantatiyAsync(int VoucherId)
    {
      var DeliveryVoucher = _receivingVoucherRepository.GetTableNoTracking()
        .Where(x => x.ReceivingVoucherId == VoucherId)
        .Include(x => x.receivingVoucherItems).ThenInclude(r => r.Product).SingleOrDefault();

      foreach (var item in DeliveryVoucher.receivingVoucherItems)
      {
        await _productService.UpdateProductQuantatiyAsync(item.ProductId, item.Quantity);
      }
    }


    public async Task<string> AddReceivingVoucherAsync(AddReceivingVoucherRequest ReceivingVoucherRequest, int VoucherStatusId = 1)
    {
      var accId = await GetDefaultSubAccountId();
      var PrimaryWarhouseId = await GetDefaultWarehouseId();
      var ReceivingVoucher = new ReceivingVoucher()
      {
        ReceivingDate = (DateTime)ReceivingVoucherRequest.ReceivingDate,
        Notes = ReceivingVoucherRequest.Notes,
        WarehouseId = ReceivingVoucherRequest.WarehouseId is null ? PrimaryWarhouseId :
        (int)ReceivingVoucherRequest.WarehouseId,
        AccountId = ReceivingVoucherRequest.AccountId is null ? accId :
        (int)ReceivingVoucherRequest.AccountId,
        VoucherStatusId = VoucherStatusId,
        SupplierId = ReceivingVoucherRequest.SupplierId,
        purchaseInvoiceId = ReceivingVoucherRequest.purchaseInvoiceId
      };


      var transact = _receivingVoucherRepository.BeginTransaction();
      try
      {
        JournalEntry JournalEntry = new JournalEntry()
        {
          EntryDate = DateTime.Now,
          Description = "Inbound Requisition - Inbound Requisition #"
        };
        var NewJournalEntry = await _journalEntryRepository.AddAsync(JournalEntry);

        ReceivingVoucher.JournalEntryID = NewJournalEntry.JournalEntryID;
        var newReceivingVoucher = await _receivingVoucherRepository.AddAsync(ReceivingVoucher);


        NewJournalEntry.Description += newReceivingVoucher.ReceivingVoucherId.ToString();
        await _journalEntryRepository.UpdateAsync(NewJournalEntry);


        decimal total = 0;

        foreach (var item in ReceivingVoucherRequest.receivingVoucherItemDT0s)
        {
          var receivingVoucherItem = new ReceivingVoucherItem()
          {
            receivingVoucherId = newReceivingVoucher.ReceivingVoucherId,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            ProductId = item.ProductId
          };
          total += item.Quantity * item.UnitPrice;

          await _receivingVoucherItemRepository.AddAsync(receivingVoucherItem);
        }

        var PurAccId = accId;



        var warehouseAccId = (await _warehouseRepository.GetByIdAsync(newReceivingVoucher.WarehouseId)).AccountId;


        if (VoucherStatusId == 1)
        {
          await AddJournalEntry(
            warehouseAccId,
            PurAccId,
            newReceivingVoucher.ReceivingVoucherId.ToString(),
            NewJournalEntry.JournalEntryID,
            total);

          await UpdateProductsQuantatiyAsync(newReceivingVoucher.ReceivingVoucherId);
        }


        await _receivingVoucherRepository.UpdateAsync(newReceivingVoucher);


        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch (Exception ex)
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied + ex.Message;
      }

    }


    public async Task<string> DeleteAsync(ReceivingVoucher ReceivingVoucher)
    {

      var transact = _receivingVoucherRepository.BeginTransaction();
      try
      {
        await _receivingVoucherRepository.DeleteAsync(ReceivingVoucher);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<GetReceivingVoucherByIdDto> GetReceivingVoucherByIdAsync(int id)
    {
      var ReceivingVoucher = _receivingVoucherRepository.GetTableNoTracking()
        .Where(x => x.ReceivingVoucherId == id)
        .Include(x => x.Warehouse)
        .Include(x => x.Account)
        .Include(x => x.VoucherStatus)
        .Include(x => x.receivingVoucherItems).ThenInclude(r => r.Product).SingleOrDefault();

      var dto = new GetReceivingVoucherByIdDto()
      {
        ReceivingVoucherId = ReceivingVoucher.ReceivingVoucherId,
        ReceivingDate = ReceivingVoucher.ReceivingDate,
        Notes = ReceivingVoucher.Notes,
        Warehouse = ReceivingVoucher.Warehouse,
        Account = ReceivingVoucher.Account,
        receivingVoucherItemsDto = new List<ReceivingVoucherItemDto>(),
        VoucherStatus = ReceivingVoucher.VoucherStatus,
        JournalEntryID = ReceivingVoucher.JournalEntryID,
        purchaseInvoiceId = ReceivingVoucher.purchaseInvoiceId,
      };

      dto.receivingVoucherItemsDto.AddRange(ReceivingVoucher.receivingVoucherItems.Select(x => new ReceivingVoucherItemDto
      {
        ReceivingVoucherItemId = x.ReceivingVoucherItemId,
        Quantity = x.Quantity,
        UnitPrice = x.UnitPrice,
        TotalPrice = x.TotalPrice,
        Product = x.Product

      }));

      return dto;
    }

    public async Task<List<GetReceivingVoucherByIdDto>> GetReceivingVouchersListAsync()
    {
      var ReceivingVouchers = _receivingVoucherRepository.GetTableNoTracking().Include(x => x.Warehouse).Include(x => x.Account).Include(x => x.VoucherStatus).ToList();

      var dtoList = new List<GetReceivingVoucherByIdDto>();

      dtoList.AddRange(ReceivingVouchers.Select(x => new GetReceivingVoucherByIdDto()
      {
        ReceivingVoucherId = x.ReceivingVoucherId,
        ReceivingDate = x.ReceivingDate,
        Notes = x.Notes,
        Warehouse = x.Warehouse,
        Account = x.Account,
        VoucherStatus = x.VoucherStatus,
        JournalEntryID = x.JournalEntryID,
        purchaseInvoiceId = x.purchaseInvoiceId,
      }));

      return dtoList;
    }

    public async Task<string> UpdateAsync(UpdateReceivingVoucherRequest ReceivingVoucherRequest)
    {

      var receivingVoucher = await _receivingVoucherRepository.GetTableAsTracking()
        .Where(x => x.ReceivingVoucherId == ReceivingVoucherRequest.ReceivingVoucherId)
        .FirstOrDefaultAsync();

      if (receivingVoucher == null)
      {
        return MessageCenter.CrudMessage.DoesNotExist;
      }


      receivingVoucher.ReceivingDate = ReceivingVoucherRequest.ReceivingDate;
      receivingVoucher.Notes = ReceivingVoucherRequest.Notes;
      receivingVoucher.WarehouseId = ReceivingVoucherRequest.WarehouseId;
      receivingVoucher.AccountId = ReceivingVoucherRequest.AccountId;



      var transact = _receivingVoucherRepository.BeginTransaction();
      try
      {
        await _receivingVoucherRepository.UpdateAsync(receivingVoucher);

        foreach (var item in ReceivingVoucherRequest.receivingVoucherItems)
        {
          var receivingVoucherItem = new ReceivingVoucherItem()
          {
            receivingVoucherId = ReceivingVoucherRequest.ReceivingVoucherId,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            ProductId = item.ProductId
          };
          if (item.ReceivingVoucherItemId != null)
          {
            receivingVoucherItem.ReceivingVoucherItemId = (int)item.ReceivingVoucherItemId;
            await _receivingVoucherItemRepository.UpdateAsync(receivingVoucherItem);

          }
          else
          {
            await _receivingVoucherItemRepository.AddAsync(receivingVoucherItem);

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
      var ReceivingVoucher = _receivingVoucherRepository.GetTableNoTracking().Where(x => x.ReceivingVoucherId == id).SingleOrDefault();

      if (ReceivingVoucher == null)
      {
        return MessageCenter.CrudMessage.DoesNotExist;
      }
      var transact = _receivingVoucherRepository.BeginTransaction();
      try
      {
        await _receivingVoucherRepository.DeleteAsync(ReceivingVoucher);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<string> ConfirmReceivingVoucherAsync(int ReceivingVoucherId)
    {
      var transact = _receivingVoucherRepository.BeginTransaction();
      try
      {

        var ReceivingVoucher = await _receivingVoucherRepository
          .GetTableAsTracking()
          .Where(x => x.ReceivingVoucherId == ReceivingVoucherId).Include(x => x.receivingVoucherItems).FirstOrDefaultAsync();



        decimal total = 0;

        foreach (var item in ReceivingVoucher.receivingVoucherItems)
        {
          total += item.Quantity * item.UnitPrice;

        }

        var PurAccId = await GetDefaultSubAccountId();



        var warehouseAccId = (await _warehouseRepository.GetByIdAsync(ReceivingVoucher.WarehouseId)).AccountId;



        await AddJournalEntry(
          warehouseAccId,
          PurAccId,
          ReceivingVoucher.ReceivingVoucherId.ToString(),
          ReceivingVoucher.JournalEntryID,
          total);

        await UpdateProductsQuantatiyAsync(ReceivingVoucher.ReceivingVoucherId);

        ReceivingVoucher.VoucherStatusId = 1;
        await _receivingVoucherRepository.UpdateAsync(ReceivingVoucher);


        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<string> RejectReceivingVoucherAsync(int ReceivingVoucherId)
    {
      var transact = _receivingVoucherRepository.BeginTransaction();
      try
      {

        var ReceivingVoucher = await _receivingVoucherRepository.GetByIdAsync(ReceivingVoucherId);


        //var journalEntity = await _journalEntryRepository.GetByIdAsync(ReceivingVoucher.JournalEntryID);
        //await _journalEntryRepository.DeleteAsync(journalEntity);
        //Cant delete becuse the journalEntity is Required in ReceivingVoucher
        ReceivingVoucher.VoucherStatusId = 3;
        await _receivingVoucherRepository.UpdateAsync(ReceivingVoucher);


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
