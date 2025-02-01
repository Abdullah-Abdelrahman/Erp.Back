using Erp.Data.Entities.SalesModule;
using Microsoft.AspNetCore.Http;

namespace Erp.Service.Abstracts.SalesModule
{
  public interface IInvoiceItemService
  {
    public Task<List<InvoiceItem>> GetInvoiceItemsListAsync();

    public Task<InvoiceItem> GetInvoiceItemByIdAsync(int id);

    public Task<string> AddInvoiceItem(InvoiceItem InvoiceItem, List<int> contentDto, IFormFile? ImageFile, string? webRootPath);

    public Task<string> UpdateAsync(InvoiceItem InvoiceItem);

    public Task<string> DeleteAsync(InvoiceItem InvoiceItem);
  }
}
