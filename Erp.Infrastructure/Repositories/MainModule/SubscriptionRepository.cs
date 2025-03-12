using Erp.Data.Entities.MainModule;
using Erp.Infrastructure.Abstracts.MainModule;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.MainModule
{
  public class SubscriptionRepository : GenericRepository<Subscription>, ISubscriptionRepository
  {
    private readonly DbSet<Subscription> _Subscriptions;
    public SubscriptionRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _Subscriptions = dbContext.Set<Subscription>();

    }
  }
}
