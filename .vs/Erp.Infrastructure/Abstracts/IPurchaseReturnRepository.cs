using Erp.Data.Entities;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts
{
  public interface IPurchaseReturnRepository : IGenericRepository<PurchaseReturn>
  {
    public Task<string> AddPurchaseReturnAsync(PurchaseReturn PurchaseReturn);

    public Task<PurchaseReturn> GetPurchaseReturnByIdAsync(int id);

    public Task<string> UpdatePurchaseReturnAsync(PurchaseReturn request);
  }
}
