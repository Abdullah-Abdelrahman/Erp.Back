using Erp.Data.Entities.AccountsModule;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.AccountsModule
{
  public interface IJournalEntryDetailRepository : IGenericRepository<JournalEntryDetail>
  {
    public Task<string> AddJournalEntryDetailAsync(JournalEntryDetail JournalEntryDetail);

    public Task<JournalEntryDetail> GetJournalEntryDetailByIdAsync(int id);

    public Task<string> UpdateJournalEntryDetailAsync(JournalEntryDetail request);
  }
}
