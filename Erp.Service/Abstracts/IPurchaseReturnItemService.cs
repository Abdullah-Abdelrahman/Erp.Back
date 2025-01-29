using Erp.Data.Entities.PurchasesModule;
using Microsoft.AspNetCore.Http;

namespace Erp.Service.Abstracts
{
  public interface IPurchaseReturnItemService
  {
    public Task<List<PurchaseReturnItem>> GetPurchaseReturnItemsListAsync();

    public Task<PurchaseReturnItem> GetPurchaseReturnItemByIdAsync(int id);

    public Task<string> AddPurchaseReturnItem(PurchaseReturnItem PurchaseReturnItem, List<int> contentDto, IFormFile? ImageFile, string? webRootPath);

    public Task<string> UpdateAsync(PurchaseReturnItem PurchaseReturnItem);

    public Task<string> DeleteAsync(PurchaseReturnItem PurchaseReturnItem);
  }
}
