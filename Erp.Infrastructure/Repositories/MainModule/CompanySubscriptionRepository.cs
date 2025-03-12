using Erp.Data.Entities.MainModule;
using Erp.Infrastructure.Abstracts.MainModule;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.MainModule
{
  public class CompanySubscriptionRepository : GenericRepository<CompanySubscription>, ICompanySubscriptionRepository
  {
    private readonly DbSet<CompanySubscription> _CompanySubscriptions;
    public CompanySubscriptionRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _CompanySubscriptions = dbContext.Set<CompanySubscription>();

    }
  }
}
