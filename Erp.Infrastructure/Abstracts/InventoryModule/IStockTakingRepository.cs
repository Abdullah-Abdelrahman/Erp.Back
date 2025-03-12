using Erp.Data.Entities.InventoryModule;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.InventoryModule
{
  public interface IStockTakingRepository : IGenericRepository<StockTaking>
  {
    public Task<string> AddStockTakingAsync(StockTaking StockTaking);

    public Task<StockTaking> GetStockTakingByIdAsync(int id);

    public Task<string> UpdateStockTakingAsync(StockTaking request);
  }
}
