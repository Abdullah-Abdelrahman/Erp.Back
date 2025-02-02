using Erp.Data.Entities.InventoryModule;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts
{
  public interface IStockTransactionRepository : IGenericRepository<StockTransaction>
  {
    public Task<string> AddStockTransactionAsync(StockTransaction StockTransaction);

    public Task<StockTransaction> GetStockTransactionByIdAsync(int id);

    public Task<string> UpdateStockTransactionAsync(StockTransaction request);
  }
}
