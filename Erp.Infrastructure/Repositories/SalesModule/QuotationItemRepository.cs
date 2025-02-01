using Erp.Data.Entities.SalesModule;
using Erp.Infrastructure.Abstracts.SalesModule;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.SalesModule
{
  public class QuotationItemRepository : GenericRepository<QuotationItem>, IQuotationItemRepository
  {
    private readonly DbSet<QuotationItem> _QuotationItems;
    public QuotationItemRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _QuotationItems = dbContext.Set<QuotationItem>();
    }

    public Task<string> AddQuotationItemAsync(QuotationItem QuotationItem)
    {
      throw new NotImplementedException();
    }

    public Task<QuotationItem> GetQuotationItemByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateQuotationItemAsync(QuotationItem request)
    {
      throw new NotImplementedException();
    }
  }
}
