using Erp.Data.Entities.PurchasesModule;
using Erp.Service.Abstracts;
using Microsoft.AspNetCore.Http;

namespace Erp.Service.Implementations
{
  public class PurchaseReturnItemService : IPurchaseReturnItemService
  {
    public Task<string> AddPurchaseReturnItem(PurchaseReturnItem PurchaseReturnItem, List<int> contentDto, IFormFile? ImageFile, string? webRootPath)
    {
      throw new NotImplementedException();
    }

    public Task<string> DeleteAsync(PurchaseReturnItem PurchaseReturnItem)
    {
      throw new NotImplementedException();
    }

    public Task<PurchaseReturnItem> GetPurchaseReturnItemByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<List<PurchaseReturnItem>> GetPurchaseReturnItemsListAsync()
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateAsync(PurchaseReturnItem PurchaseReturnItem)
    {
      throw new NotImplementedException();
    }
  }
}
