using Erp.Data.Entities.AccountsModule;

namespace Erp.Service.Abstracts.AccountsModule
{
  public interface IAccountService
  {
    Task<string> AddAccountAsync(Account account);


    Task<PrimaryAccount?> GetPrimaryAccountByIdAsync(int id);


    Task<SecondaryAccount?> GetSecondaryAccountByIdAsync(int id);

    Task<List<PrimaryAccount>> GetMainAccountListAsync();

    Task<string> UpdateAccountAsync(Account account);


    Task<string> DeleteAccountAsync(int id);

    Task<List<T>> GetAccountsByTypeAsync<T>() where T : Account;

    Task<string> GetAccountTypeByIdAsync(int accountId);

    Task<Account?> GetAccountByIdAsync(int id);
  }
}
