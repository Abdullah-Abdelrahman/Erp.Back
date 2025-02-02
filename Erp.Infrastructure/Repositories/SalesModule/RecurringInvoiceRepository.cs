using Erp.Data.Entities.SalesModule;
using Erp.Infrastructure.Abstracts.SalesModule;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.SalesModule
{
  public class RecurringInvoiceRepository : GenericRepository<RecurringInvoice>, IRecurringInvoiceRepository
  {
    private readonly DbSet<RecurringInvoice> _RecurringInvoices;
    public RecurringInvoiceRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _RecurringInvoices = dbContext.Set<RecurringInvoice>();
    }

    public Task<string> AddRecurringInvoiceAsync(RecurringInvoice RecurringInvoice)
    {
      throw new NotImplementedException();
    }

    public Task<RecurringInvoice> GetRecurringInvoiceByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateRecurringInvoiceAsync(RecurringInvoice request)
    {
      throw new NotImplementedException();
    }
  }
}
