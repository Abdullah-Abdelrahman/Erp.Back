using Erp.Data.Entities.SalesModule;
using Erp.Infrastructure.Abstracts.SalesModule;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.SalesModule
{
  public class QuotationRepository : GenericRepository<Quotation>, IQuotationRepository
  {
    private readonly DbSet<Quotation> _Quotations;
    public QuotationRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _Quotations = dbContext.Set<Quotation>();
    }

    public Task<string> AddQuotationAsync(Quotation Quotation)
    {
      throw new NotImplementedException();
    }

    public Task<Quotation> GetQuotationByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateQuotationAsync(Quotation request)
    {
      throw new NotImplementedException();
    }
  }
}
