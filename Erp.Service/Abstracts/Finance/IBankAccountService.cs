using Erp.Data.Dto.BankAccount;
using Erp.Data.Entities.Finance;

namespace Erp.Service.Abstracts.Finance
{
  public interface IBankAccountService
  {
    public Task<List<GetBankAccountByIdDto>> GetBankAccountsListAsync();

    public Task<GetBankAccountByIdDto> GetBankAccountByIdAsync(int id);

    public Task<string> AddBankAccount(AddBankAccountRequest BankAccount);

    public Task<string> UpdateAsync(UpdateBankAccountRequest BankAccount);

    public Task<string> DeleteAsync(BankAccount BankAccount);
    public Task<string> DeleteByIdAsync(int id);
  }
}
