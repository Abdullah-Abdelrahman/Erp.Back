using Erp.Data.Entities.AccountsModule;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.AccountsModule
{
  public interface IJournalEntryRepository : IGenericRepository<JournalEntry>
  {
    public Task<string> AddJournalEntryAsync(JournalEntry JournalEntry);

    public Task<JournalEntry> GetJournalEntryByIdAsync(int id);

    public Task<string> UpdateJournalEntryAsync(JournalEntry request);
  }
}
