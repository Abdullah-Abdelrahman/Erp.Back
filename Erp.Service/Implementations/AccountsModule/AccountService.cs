using Erp.Data.Entities.AccountsModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.AccountsModule;
using Erp.Service.Abstracts.AccountsModule;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations.AccountsModule
{
  public class AccountService : IAccountService
  {
    private readonly IAccountRepository<Account> _accountRepository;
    private readonly IAccountRepository<PrimaryAccount> _primaryAccountRepository;
    private readonly IAccountRepository<SecondaryAccount> _secondaryAccountRepository;

    private readonly IJournalEntryDetailRepository _JournalEntryDetailRepository;


    // Constructor that injects the repository
    public AccountService(IAccountRepository<Account> accountRepository, IAccountRepository<PrimaryAccount> primaryAccountRepository,
            IAccountRepository<SecondaryAccount> secondaryAccountRepository, IJournalEntryDetailRepository journalEntryDetailRepository)
    {
      _accountRepository = accountRepository;

      _primaryAccountRepository = primaryAccountRepository;
      _secondaryAccountRepository = secondaryAccountRepository;
      _JournalEntryDetailRepository = journalEntryDetailRepository;
    }

    public async Task<string> AddAccountAsync(Account account)
    {
      try
      {
        return await _accountRepository.AddAccountAsync(account);
      }
      catch
      {
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<PrimaryAccount?> GetPrimaryAccountByIdAsync(int id)
    {
      try
      {
        var result = await _primaryAccountRepository.GetTableNoTracking().Where(x => x.AccountID == id).SingleOrDefaultAsync();

        result.ChildAccounts = await _accountRepository.GetTableNoTracking().Where(x => x.ParentAccountID == result.AccountID).ToListAsync();
        return result;
      }
      catch
      {
        return null;
      }
    }


    public async Task<string> UpdateAccountAsync(Account account)
    {
      try
      {
        return await _accountRepository.UpdateAccountAsync(account);
      }
      catch
      {
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<string> DeleteAccountAsync(int id)
    {
      try
      {
        var account = await _accountRepository.GetAccountByIdAsync(id);
        if (account != null)
        {

          await _accountRepository.DeleteAsync(account);
          return MessageCenter.CrudMessage.Success;
        }
        return MessageCenter.CrudMessage.DoesNotExist;
      }
      catch
      {
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<List<T>> GetAccountsByTypeAsync<T>() where T : Account
    {
      try
      {
        return await _accountRepository.GetAccountsByTypeAsync<T>();
      }
      catch
      {
        return new List<T>();
      }
    }

    public async Task<string> GetAccountTypeByIdAsync(int accountId)
    {
      var primaryAccount = await _primaryAccountRepository.GetAccountByIdAsync(accountId);
      if (primaryAccount != null) return "Primary";

      var secondaryAccount = await _secondaryAccountRepository.GetAccountByIdAsync(accountId);
      if (secondaryAccount != null) return "Secondary";

      return "Unknown";
    }

    public async Task<SecondaryAccount?> GetSecondaryAccountByIdAsync(int id)
    {
      try
      {
        var result = await _secondaryAccountRepository.GetTableNoTracking().Where(x => x.AccountID == id).Include(x => x.journalEntryDetails).SingleOrDefaultAsync();

        result.journalEntryDetails = await _JournalEntryDetailRepository.GetTableNoTracking().Where(x => x.AccountID == result.AccountID).Include(x => x.Account).Include(x => x.CostCenter).ToListAsync();


        return result;
      }
      catch
      {
        return null;
      }
    }

    public async Task<List<PrimaryAccount>> GetMainAccountListAsync()
    {
      try
      {
        var result = await _primaryAccountRepository.GetTableNoTracking().Where(x => x.ParentAccountID == null).Include(x => x.ChildAccounts).ToListAsync();


        foreach (var primaryAccount in result)
        {
          primaryAccount.ChildAccounts = await _accountRepository.GetTableNoTracking().Where(x => x.ParentAccountID == primaryAccount.AccountID).ToListAsync();
        }

        return result;
      }
      catch
      {
        return null;
      }
    }

    public async Task<Account?> GetAccountByIdAsync(int id)
    {
      return await _accountRepository.GetByIdAsync(id);
    }
  }
}
