using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.MainModule;
using Erp.Service.Abstracts.MainModule;
using Microsoft.EntityFrameworkCore;
using E = Erp.Data.Entities.MainModule;
namespace Erp.Service.Implementations.MainModule
{
  public class SubscriptionService : ISubscriptionService
  {
    private readonly ISubscriptionRepository _SubscriptionRepository;
    public SubscriptionService(ISubscriptionRepository SubscriptionRepository)
    {
      _SubscriptionRepository = SubscriptionRepository;
    }
    public async Task<string> AddSubscriptionAsync(E.Subscription Subscription)
    {
      if (Subscription.Description == null)
      {
        Subscription.Description = string.Empty;
      }


      var newSubscription = await _SubscriptionRepository.AddAsync(Subscription);
      if (newSubscription != null)
      {
        return MessageCenter.CrudMessage.Success;
      }
      else
      {
        return "Somthing bad happend :";
      }
    }

    public async Task<string> DeleteAsync(E.Subscription Subscription)
    {
      try
      {
        await _SubscriptionRepository.DeleteAsync(Subscription);
        return MessageCenter.CrudMessage.Success;
      }
      catch (Exception ex)
      {
        return "There is a problem in deleteing the Subscription : " + ex.Message;
      }

    }

    public async Task<E.Subscription> GetSubscriptionByIdAsync(int id)
    {
      var Subscription = await _SubscriptionRepository.GetTableNoTracking().Where(x => x.Id == id).SingleOrDefaultAsync();

      return Subscription;
    }

    public async Task<List<E.Subscription>> GetSubscriptionsListAsync()
    {
      var Subscriptions = await _SubscriptionRepository.GetTableNoTracking().ToListAsync();

      return Subscriptions;
    }

    public async Task<string> UpdateAsync(E.Subscription Subscription)
    {
      var transact = _SubscriptionRepository.BeginTransaction();
      try
      {
        await _SubscriptionRepository.UpdateAsync(Subscription);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }
  }
}
