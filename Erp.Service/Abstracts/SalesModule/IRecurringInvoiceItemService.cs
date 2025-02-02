using Erp.Data.Entities.SalesModule;
using Microsoft.AspNetCore.Http;

namespace Erp.Service.Abstracts.SalesModule
{
  public interface IRecurringInvoiceItemService
  {
    public Task<List<RecurringInvoiceItem>> GetRecurringInvoiceItemsListAsync();

    public Task<RecurringInvoiceItem> GetRecurringInvoiceItemByIdAsync(int id);

    public Task<string> AddRecurringInvoiceItem(RecurringInvoiceItem RecurringInvoiceItem, List<int> contentDto, IFormFile? ImageFile, string? webRootPath);

    public Task<string> UpdateAsync(RecurringInvoiceItem RecurringInvoiceItem);

    public Task<string> DeleteAsync(RecurringInvoiceItem RecurringInvoiceItem);
  }
}
