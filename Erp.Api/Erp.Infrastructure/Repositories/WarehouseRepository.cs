using Erp.Data.Entities;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories
{
  public class WarehouseRepository : GenericRepository<Warehouse>, IWarehouseRepository
  {
    private readonly DbSet<Warehouse> _Warehouses;
    public WarehouseRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _Warehouses = dbContext.Set<Warehouse>();
    }

    public async Task<string> AddWarehouseAsync(Warehouse Warehouse)
    {
      var result = await _Warehouses.AddAsync(Warehouse);

      if (result == null)
      {
        return "Cant Add";
      }
      else
      {
        return MessageCenter.CrudMessage.Success;
      }
    }

    public async Task<Warehouse> GetWarehouseByIdAsync(int id)
    {
      return await _Warehouses.FindAsync(id);
    }

    public async Task<List<Warehouse>> GetWarehouseListAsync()
    {
      return await _Warehouses.ToListAsync();
    }

    public async Task<string> UpdateWarehouseAsync(Warehouse request)
    {
      var result = _Warehouses.Update(request);

      return MessageCenter.CrudMessage.Success;
    }
  }


}
