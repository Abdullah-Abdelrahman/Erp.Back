using Erp.Data.Dto.RecurringInvoice;
using Erp.Data.Entities.SalesModule;

namespace Erp.Service.Abstracts.SalesModule
{
  public interface IRecurringInvoiceService
  {
    public Task<List<GetRecurringInvoiceByIdDto>> GetRecurringInvoicesListAsync();

    public Task<GetRecurringInvoiceByIdDto> GetRecurringInvoiceByIdAsync(int id);

    public Task<string> AddRecurringInvoice(AddRecurringInvoiceRequest RecurringInvoice);

    public Task<string> UpdateAsync(UpdateRecurringInvoiceRequest RecurringInvoice);

    public Task<string> DeleteAsync(RecurringInvoice RecurringInvoice);
    public Task<string> DeleteByIdAsync(int id);
  }
}
