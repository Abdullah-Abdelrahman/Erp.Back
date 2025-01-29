using Erp.Data.Entities.PurchasesModule;
using Erp.Infrastructure.Abstracts;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories
{
  public class PurchaseReturnItemRepository : GenericRepository<PurchaseReturnItem>, IPurchaseReturnItemRepository
  {
    private readonly DbSet<PurchaseReturnItem> _PurchaseReturnItems;
    public PurchaseReturnItemRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _PurchaseReturnItems = dbContext.Set<PurchaseReturnItem>();
    }

    public Task<string> AddPurchaseReturnItemAsync(PurchaseReturnItem PurchaseReturnItem)
    {
      throw new NotImplementedException();
    }

    public Task<PurchaseReturnItem> GetPurchaseReturnItemByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdatePurchaseReturnItemAsync(PurchaseReturnItem request)
    {
      throw new NotImplementedException();
    }
  }
}
