using Erp.Data.Entities.InventoryModule;
using Erp.Infrastructure.Abstracts;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories
{
  public class StockTransactionRepository : GenericRepository<StockTransaction>, IStockTransactionRepository
  {
    private readonly DbSet<StockTransaction> _StockTransactions;
    public StockTransactionRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _StockTransactions = dbContext.Set<StockTransaction>();
    }

    public Task<string> AddStockTransactionAsync(StockTransaction StockTransaction)
    {
      throw new NotImplementedException();
    }

    public Task<StockTransaction> GetStockTransactionByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateStockTransactionAsync(StockTransaction request)
    {
      throw new NotImplementedException();
    }
  }


}
