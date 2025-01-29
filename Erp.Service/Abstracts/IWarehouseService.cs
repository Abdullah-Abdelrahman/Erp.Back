using Erp.Data.Entities.InventoryModule;

namespace Erp.Service.Abstracts
{
  public interface IWarehouseService
  {

    public Task<List<Warehouse>> GetWarehousesListAsync();

    public Task<Warehouse> GetWarehouseByIdAsync(int id);

    public Task<string> AddWarehouse(Warehouse Warehouse);

    public Task<string> UpdateAsync(Warehouse Warehouse);

    public Task<string> DeleteAsync(Warehouse Warehouse);
  }
}
