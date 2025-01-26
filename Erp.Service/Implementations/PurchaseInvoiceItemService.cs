using Erp.Data.Entities;
using Erp.Service.Abstracts;
using Microsoft.AspNetCore.Http;

namespace Erp.Service.Implementations
{
  public class PurchaseInvoiceItemService : IPurchaseInvoiceItemService
  {
    public Task<string> AddPurchaseInvoiceItem(PurchaseInvoiceItem PurchaseInvoiceItem, List<int> contentDto, IFormFile? ImageFile, string? webRootPath)
    {
      throw new NotImplementedException();
    }

    public Task<string> DeleteAsync(PurchaseInvoiceItem PurchaseInvoiceItem)
    {
      throw new NotImplementedException();
    }

    public Task<PurchaseInvoiceItem> GetPurchaseInvoiceItemByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<List<PurchaseInvoiceItem>> GetPurchaseInvoiceItemsListAsync()
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateAsync(PurchaseInvoiceItem PurchaseInvoiceItem)
    {
      throw new NotImplementedException();
    }
  }
}
