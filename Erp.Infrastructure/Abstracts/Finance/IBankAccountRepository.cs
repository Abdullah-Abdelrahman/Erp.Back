using Erp.Data.Entities.Finance;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.Finance
{
  public interface IBankAccountRepository : IGenericRepository<BankAccount>
  {
    public Task<string> AddBankAccountAsync(BankAccount BankAccount);

    public Task<BankAccount?> GetBankAccountByIdAsync(int id);

    public Task<List<BankAccount>> GetBankAccountsListAsync();

    public Task<string> UpdateBankAccountAsync(BankAccount request);
  }

}
