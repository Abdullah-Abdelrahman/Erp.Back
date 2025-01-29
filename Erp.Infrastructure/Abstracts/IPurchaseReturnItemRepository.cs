using Erp.Data.Entities.PurchasesModule;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts
{
  public interface IPurchaseReturnItemRepository : IGenericRepository<PurchaseReturnItem>
  {
    public Task<string> AddPurchaseReturnItemAsync(PurchaseReturnItem PurchaseReturnItem);

    public Task<PurchaseReturnItem> GetPurchaseReturnItemByIdAsync(int id);

    public Task<string> UpdatePurchaseReturnItemAsync(PurchaseReturnItem request);
  }
}
