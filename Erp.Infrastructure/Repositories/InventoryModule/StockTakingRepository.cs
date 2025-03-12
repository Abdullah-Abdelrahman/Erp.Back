using Erp.Data.Entities.InventoryModule;
using Erp.Infrastructure.Abstracts.InventoryModule;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.InventoryModule
{
  public class StockTakingRepository : GenericRepository<StockTaking>, IStockTakingRepository
  {
    private readonly DbSet<StockTaking> _StockTakings;
    public StockTakingRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _StockTakings = dbContext.Set<StockTaking>();
    }

    public Task<string> AddStockTakingAsync(StockTaking StockTaking)
    {
      throw new NotImplementedException();
    }

    public Task<StockTaking> GetStockTakingByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateStockTakingAsync(StockTaking request)
    {
      throw new NotImplementedException();
    }
  }
}

