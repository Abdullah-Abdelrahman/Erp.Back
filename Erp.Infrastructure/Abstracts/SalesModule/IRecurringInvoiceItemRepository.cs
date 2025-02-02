using Erp.Data.Entities.SalesModule;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.SalesModule
{
  public interface IRecurringInvoiceItemRepository : IGenericRepository<RecurringInvoiceItem>
  {
    public Task<string> AddRecurringInvoiceItemAsync(RecurringInvoiceItem RecurringInvoiceItem);

    public Task<RecurringInvoiceItem> GetRecurringInvoiceItemByIdAsync(int id);

    public Task<string> UpdateRecurringInvoiceItemAsync(RecurringInvoiceItem request);
  }
}
