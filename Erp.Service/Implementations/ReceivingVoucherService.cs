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


    // Isupplair
    public ReceivingVoucherService(
      IReceivingVoucherRepository receivingVoucherRepository,
      IProductService productService,
      IWarehouseRepository warehouseRepository,
      IReceivingVoucherItemRepository receivingVoucherItemRepository,
      IAccountRepository<SecondaryAccount> accountRepository,
      IVoucherStatusRepository voucherStatusRepository)
    {
      _receivingVoucherRepository = receivingVoucherRepository;
      _receivingVoucherItemRepository = receivingVoucherItemRepository;
      _productService = productService;
      _warehouseRepository = warehouseRepository;
      _accountRepository = accountRepository;
      _voucherStatusRepository = voucherStatusRepository;
    }
    private async Task<int> GetDefaultSubAccountId()
    {
      var Acc = (await _accountRepository.GetTableNoTracking().
        Where(a => a.AccountName == "Other Creditors").SingleOrDefaultAsync());
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
    public async Task<string> AddReceivingVoucher(AddReceivingVoucherRequest ReceivingVoucherRequest)
    {
      var accId = await GetDefaultSubAccountId();
      var PrimaryWarhouseId = await GetDefaultSubAccountId();
      var ReceivingVoucher = new ReceivingVoucher()
      {
        ReceivingDate = (DateTime)ReceivingVoucherRequest.ReceivingDate,
        Notes = ReceivingVoucherRequest.Notes,
        WarehouseId = ReceivingVoucherRequest.WarehouseId is null ? PrimaryWarhouseId :
        (int)ReceivingVoucherRequest.WarehouseId,
        AccountId = ReceivingVoucherRequest.AccountId is null ? accId :
        (int)ReceivingVoucherRequest.AccountId,
        VoucherStatusId = 1
      };


      var transact = _receivingVoucherRepository.BeginTransaction();
      try
      {
        var newReceivingVoucher = await _receivingVoucherRepository.AddAsync(ReceivingVoucher);

        foreach (var item in ReceivingVoucherRequest.receivingVoucherItemDT0s)
        {
          var receivingVoucherItem = new ReceivingVoucherItem()
          {
            receivingVoucherId = newReceivingVoucher.ReceivingVoucherId,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            ProductId = item.ProductId
          };

          await _receivingVoucherItemRepository.AddAsync(receivingVoucherItem);
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
        VoucherStatus = ReceivingVoucher.VoucherStatus
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

  }


}
