using Erp.Data.Entities.MainModule;

namespace Erp.Service.Abstracts.MainModule
{
  public interface ISubscriptionService
  {
    public Task<List<Subscription>> GetSubscriptionsListAsync();

    public Task<Subscription> GetSubscriptionByIdAsync(int id);

    public Task<string> AddSubscriptionAsync(Subscription Subscription);

    public Task<string> UpdateAsync(Subscription Subscription);

    public Task<string> DeleteAsync(Subscription Subscription);
  }
}
