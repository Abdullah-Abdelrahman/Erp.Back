using Erp.Data.Entities.AccountsModule;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.AccountsModule
{
  public interface IAccountRepository<TAccount> : IGenericRepository<TAccount> where TAccount : Account
  {
    Task<string> AddAccountAsync(TAccount account);
    Task<TAccount?> GetAccountByIdAsync(int id);
    Task<List<TAccount>> GetAccountsListAsync();
    Task<string> UpdateAccountAsync(TAccount account);
    Task<List<T>> GetAccountsByTypeAsync<T>() where T : Account;
  }

}
