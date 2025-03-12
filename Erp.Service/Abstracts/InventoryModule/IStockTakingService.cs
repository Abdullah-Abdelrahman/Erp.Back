using Erp.Data.Entities.InventoryModule;

namespace Erp.Service.Abstracts.InventoryModule
{
  public interface IStockTakingService
  {
    public Task<List<StockTaking>> GetStockTakingsListAsync();

    public Task<StockTaking> GetStockTakingByIdAsync(int id);

    public Task<string> AddStockTakingAsync(StockTaking StockTaking);

    public Task<string> AddStockTakingItemAsync(StockTakingItem Item);

    public Task<string> UpdateAsync(StockTaking StockTaking);

    public Task<string> DeleteAsync(StockTaking StockTaking);
  }
}
