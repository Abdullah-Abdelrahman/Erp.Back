using Erp.Data.Entities.SalesModule;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.SalesModule
{
  public interface IInvoiceRepository : IGenericRepository<Invoice>
  {
    public Task<string> AddInvoiceAsync(Invoice Invoice);

    public Task<Invoice> GetInvoiceByIdAsync(int id);

    public Task<string> UpdateInvoiceAsync(Invoice request);
  }
}
