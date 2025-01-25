using Erp.Data.Entities;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts;
using Erp.Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations
{
  public class WarehouseService : IWarehouseService
  {
    private readonly IWarehouseRepository _warehouseRepository;
    public WarehouseService(IWarehouseRepository warehouseRepository)
    {
      _warehouseRepository = warehouseRepository;
    }
    public async Task<string> AddWarehouse(Warehouse Warehouse)
    {
      var newWarehouse = await _warehouseRepository.AddAsync(Warehouse);
      if (newWarehouse != null)
      {
        return MessageCenter.CrudMessage.Success;
      }
      else
      {
        return "Somthing bad happend :";
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
