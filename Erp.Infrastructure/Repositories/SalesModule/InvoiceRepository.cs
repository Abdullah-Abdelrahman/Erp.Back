using Erp.Data.Entities.SalesModule;
using Erp.Infrastructure.Abstracts.SalesModule;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.SalesModule
{
  public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
  {
    private readonly DbSet<Invoice> _Invoices;
    public InvoiceRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _Invoices = dbContext.Set<Invoice>();
    }

    public Task<string> AddInvoiceAsync(Invoice Invoice)
    {
      throw new NotImplementedException();
    }

    public Task<Invoice> GetInvoiceByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateInvoiceAsync(Invoice request)
    {
      throw new NotImplementedException();
    }
  }
}
