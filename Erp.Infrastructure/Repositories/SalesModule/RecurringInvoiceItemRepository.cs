using Erp.Data.Entities.SalesModule;
using Erp.Infrastructure.Abstracts.SalesModule;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.SalesModule
{
  public class RecurringInvoiceItemRepository : GenericRepository<RecurringInvoiceItem>, IRecurringInvoiceItemRepository
  {
    private readonly DbSet<RecurringInvoiceItem> _RecurringInvoiceItems;
    public RecurringInvoiceItemRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _RecurringInvoiceItems = dbContext.Set<RecurringInvoiceItem>();
    }

    public Task<string> AddRecurringInvoiceItemAsync(RecurringInvoiceItem RecurringInvoiceItem)
    {
      throw new NotImplementedException();
    }

    public Task<RecurringInvoiceItem> GetRecurringInvoiceItemByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateRecurringInvoiceItemAsync(RecurringInvoiceItem request)
    {
      throw new NotImplementedException();
    }
  }
}
