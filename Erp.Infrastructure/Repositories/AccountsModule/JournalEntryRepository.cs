using Erp.Data.Entities.AccountsModule;
using Erp.Infrastructure.Abstracts.AccountsModule;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.AccountsModule
{
  public class JournalEntryRepository : GenericRepository<JournalEntry>, IJournalEntryRepository
  {
    private readonly DbSet<JournalEntry> _JournalEntrys;
    public JournalEntryRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _JournalEntrys = dbContext.Set<JournalEntry>();
    }

    public Task<string> AddJournalEntryAsync(JournalEntry JournalEntry)
    {
      throw new NotImplementedException();
    }

    public Task<JournalEntry> GetJournalEntryByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateJournalEntryAsync(JournalEntry request)
    {
      throw new NotImplementedException();
    }
  }
}
