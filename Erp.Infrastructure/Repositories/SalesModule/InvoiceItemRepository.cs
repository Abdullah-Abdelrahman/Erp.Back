using Erp.Data.Entities.SalesModule;
using Erp.Infrastructure.Abstracts.SalesModule;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.SalesModule
{
  public class InvoiceItemRepository : GenericRepository<InvoiceItem>, IInvoiceItemRepository
  {
    private readonly DbSet<InvoiceItem> _InvoiceItems;
    public InvoiceItemRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _InvoiceItems = dbContext.Set<InvoiceItem>();
    }

    public Task<string> AddInvoiceItemAsync(InvoiceItem InvoiceItem)
    {
      throw new NotImplementedException();
    }

    public Task<InvoiceItem> GetInvoiceItemByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateInvoiceItemAsync(InvoiceItem request)
    {
      throw new NotImplementedException();
    }
  }
}
