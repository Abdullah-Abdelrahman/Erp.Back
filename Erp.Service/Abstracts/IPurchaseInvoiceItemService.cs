using Erp.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace Erp.Service.Abstracts
{
  public interface IPurchaseInvoiceItemService
  {
    public Task<List<PurchaseInvoiceItem>> GetPurchaseInvoiceItemsListAsync();

    public Task<PurchaseInvoiceItem> GetPurchaseInvoiceItemByIdAsync(int id);

    public Task<string> AddPurchaseInvoiceItem(PurchaseInvoiceItem PurchaseInvoiceItem, List<int> contentDto, IFormFile? ImageFile, string? webRootPath);

    public Task<string> UpdateAsync(PurchaseInvoiceItem PurchaseInvoiceItem);

    public Task<string> DeleteAsync(PurchaseInvoiceItem PurchaseInvoiceItem);
  }
}
