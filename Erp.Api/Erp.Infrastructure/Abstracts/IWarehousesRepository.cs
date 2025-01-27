using Erp.Data.Entities;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts
{
  public interface IWarehouseRepository : IGenericRepository<Warehouse>
  {
    public Task<string> AddWarehouseAsync(Warehouse Warehouse);

    public Task<Warehouse> GetWarehouseByIdAsync(int id);

    public Task<string> UpdateWarehouseAsync(Warehouse request);

    public Task<List<Warehouse>> GetWarehouseListAsync();
  }
}
