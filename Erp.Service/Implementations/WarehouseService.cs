using Erp.Data.Entities.AccountsModule;
using Erp.Data.Entities.InventoryModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts;
using Erp.Infrastructure.Abstracts.AccountsModule;
using Erp.Service.Abstracts;
using Erp.Service.Abstracts.AccountsModule;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations
{
  public class WarehouseService : IWarehouseService
  {
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IAccountRepository<SecondaryAccount> _SecondaryAccountRepository;
    private readonly IAccountRepository<PrimaryAccount> _PrimaryAccountRepository;
    private readonly IAccountService _accountService;

    public WarehouseService(IWarehouseRepository warehouseRepository,
      IAccountRepository<SecondaryAccount> SecondaryAccountRepository,
        IAccountRepository<PrimaryAccount> PrimaryAccountRepository,
        IAccountService accountService)
    {
      _warehouseRepository = warehouseRepository;
      _SecondaryAccountRepository = SecondaryAccountRepository;
      _PrimaryAccountRepository = PrimaryAccountRepository;
      _accountService = accountService;
    }
    public async Task TransformProductQuantatiyAsync(int ProId, int Ware1Id, int Ware2Id, int Qua)
    {
      var Ware1 = await _warehouseRepository.GetByIdAsync(Ware1Id);
      var Ware2 = await _warehouseRepository.GetByIdAsync(Ware2Id);


      return;
    }
    public async Task<string> AddWarehouse(Warehouse Warehouse)
    {

      var transact = _warehouseRepository.BeginTransaction();
      try
      {
        var acc = new SecondaryAccount()
        {
          AccountName = Warehouse.WarehouseName,
          Type = AccountType.debtor,
          Balance = 0,
          ParentAccountID = (await _PrimaryAccountRepository.GetTableNoTracking().Where(a => a.AccountName == "Inventory").SingleOrDefaultAsync())?.AccountID,
          IsActive = true,
          CreatedDate = DateTime.UtcNow,
        };
        await _accountService.AddAccountAsync(acc);
        Warehouse.AccountId = acc.AccountID;
        var newWarehouse = await _warehouseRepository.AddAsync(Warehouse);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch (Exception ex)
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied + ex.Message;
      }



    }

    public async Task<string> DeleteAsync(Warehouse Warehouse)
    {
      try
      {
        await _warehouseRepository.DeleteAsync(Warehouse);
        return MessageCenter.CrudMessage.Success;
      }
      catch (Exception ex)
      {
        return "There is a problem in deleteing the Warehouse : " + ex.Message;
      }
    }

    public async Task<Warehouse> GetWarehouseByIdAsync(int id)
    {
      var Warehouse = _warehouseRepository.GetTableNoTracking().Where(x => x.WarehouseId == id).Include(w => w.deliveryVouchers).Include(w => w.receivingVouchers).Include(w => w.StockTransactions).SingleOrDefault();

      return Warehouse;
    }

    public async Task<List<Warehouse>> GetWarehousesListAsync()
    {
      var Warehouses = _warehouseRepository.GetTableNoTracking().ToList();

      return Warehouses;
    }

    public async Task<string> UpdateAsync(Warehouse Warehouse)
    {
      var transact = _warehouseRepository.BeginTransaction();
      try
      {
        await _warehouseRepository.UpdateAsync(Warehouse);

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
