using Erp.Data.Entities.SalesModule;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.SalesModule
{
  public interface IRecurringInvoiceRepository : IGenericRepository<RecurringInvoice>
  {
    public Task<string> AddRecurringInvoiceAsync(RecurringInvoice RecurringInvoice);

    public Task<RecurringInvoice> GetRecurringInvoiceByIdAsync(int id);

    public Task<string> UpdateRecurringInvoiceAsync(RecurringInvoice request);
  }
}
