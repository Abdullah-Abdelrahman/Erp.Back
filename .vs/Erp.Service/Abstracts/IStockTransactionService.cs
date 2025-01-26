using Erp.Data.Entities;

namespace Erp.Service.Abstracts
{
  public interface IStockTransactionService
  {

    public Task<List<StockTransaction>> GetStockTransactionsListAsync();

    public Task<StockTransaction> GetStockTransactionByIdAsync(int id);

    public Task<string> AddStockTransaction(StockTransaction StockTransaction);

    public Task<string> UpdateAsync(StockTransaction StockTransaction);

    public Task<string> DeleteAsync(StockTransaction StockTransaction);
  }
}
