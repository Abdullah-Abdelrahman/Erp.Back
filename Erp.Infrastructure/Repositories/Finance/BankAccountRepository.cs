using Erp.Data.Entities.Finance;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.Finance;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.Finance
{
  public class BankAccountRepository : GenericRepository<BankAccount>, IBankAccountRepository
  {
    private readonly DbSet<BankAccount> _BankAccounts;
    public BankAccountRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _BankAccounts = dbContext.Set<BankAccount>();

    }


    public async Task<string> AddBankAccountAsync(BankAccount BankAccount)
    {
      var result = await _BankAccounts.AddAsync(BankAccount);

      if (result == null)
      {
        return "Cant Add";
      }
      else
      {
        return MessageCenter.CrudMessage.Success;
      }
    }

    public async Task<BankAccount?> GetBankAccountByIdAsync(int id)
    {
      return await _BankAccounts.FindAsync(id);

    }

    public async Task<List<BankAccount>> GetBankAccountsListAsync()
    {
      return await _BankAccounts.ToListAsync();
    }

    public async Task<string> UpdateBankAccountAsync(BankAccount request)
    {
      var result = _BankAccounts.Update(request);

      return MessageCenter.CrudMessage.Success;
    }
  }
}
