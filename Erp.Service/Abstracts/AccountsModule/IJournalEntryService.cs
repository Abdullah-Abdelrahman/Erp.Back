using Erp.Data.Dto.JournalEntry;
using Erp.Data.Entities.AccountsModule;

namespace Erp.Service.Abstracts.AccountsModule
{
  public interface IJournalEntryService
  {
    public Task<List<GetJournalEntryByIdDto>> GetJournalEntrysListAsync();

    public Task<GetJournalEntryByIdDto> GetJournalEntryByIdAsync(int id);

    public Task<string> AddJournalEntry(AddJournalEntryRequest JournalEntry);

    public Task<string> UpdateAsync(UpdateJournalEntryRequest JournalEntry);

    public Task<string> DeleteAsync(JournalEntry JournalEntry);
    public Task<string> DeleteByIdAsync(int id);
  }
}
