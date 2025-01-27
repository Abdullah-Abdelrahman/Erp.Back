using Erp.Data.Entities.AccountsModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.AccountsModule;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.AccountsModule
{
  public class AccountRepository<TAccount> : GenericRepository<TAccount>, IAccountRepository<TAccount> where TAccount : Account
  {
    private readonly DbSet<TAccount> _accounts;

    public AccountRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _accounts = dbContext.Set<TAccount>();
    }

    public async Task<string> AddAccountAsync(TAccount account)
    {
      await _accounts.AddAsync(account);
      await _dbContext.SaveChangesAsync(); // Ensure changes are saved

      return MessageCenter.CrudMessage.Success;
    }

    public async Task<TAccount?> GetAccountByIdAsync(int id)
    {
      return await _accounts.FindAsync(id);
    }

    public async Task<List<TAccount>> GetAccountsListAsync()
    {
      return await _accounts.ToListAsync();
    }

    public async Task<string> UpdateAccountAsync(TAccount account)
    {
      _accounts.Update(account);
      await _dbContext.SaveChangesAsync();

      return MessageCenter.CrudMessage.Success;
    }

    public async Task<List<T>> GetAccountsByTypeAsync<T>() where T : Account
    {
      return await _accounts.OfType<T>().ToListAsync();
    }

  }
}
