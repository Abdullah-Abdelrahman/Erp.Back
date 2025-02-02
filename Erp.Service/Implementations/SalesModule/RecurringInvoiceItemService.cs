using Erp.Data.Entities.SalesModule;
using Erp.Service.Abstracts.SalesModule;
using Microsoft.AspNetCore.Http;

namespace Erp.Service.Implementations.SalesModule
{
  internal class RecurringInvoiceItemService : IRecurringInvoiceItemService
  {
    public Task<string> AddRecurringInvoiceItem(RecurringInvoiceItem RecurringInvoiceItem, List<int> contentDto, IFormFile? ImageFile, string? webRootPath)
    {
      throw new NotImplementedException();
    }

    public Task<string> DeleteAsync(RecurringInvoiceItem RecurringInvoiceItem)
    {
      throw new NotImplementedException();
    }

    public Task<RecurringInvoiceItem> GetRecurringInvoiceItemByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<List<RecurringInvoiceItem>> GetRecurringInvoiceItemsListAsync()
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateAsync(RecurringInvoiceItem RecurringInvoiceItem)
    {
      throw new NotImplementedException();
    }
  }
}
