using Erp.Data.Entities.SalesModule;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.SalesModule
{
  public interface IInvoiceItemRepository : IGenericRepository<InvoiceItem>
  {
    public Task<string> AddInvoiceItemAsync(InvoiceItem InvoiceItem);

    public Task<InvoiceItem> GetInvoiceItemByIdAsync(int id);

    public Task<string> UpdateInvoiceItemAsync(InvoiceItem request);
  }
}
