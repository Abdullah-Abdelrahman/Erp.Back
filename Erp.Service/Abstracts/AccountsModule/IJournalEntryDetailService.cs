using Erp.Data.Entities.AccountsModule;
using Microsoft.AspNetCore.Http;

namespace Erp.Service.Abstracts.AccountsModule
{
  public interface IJournalEntryDetailService
  {
    public Task<List<JournalEntryDetail>> GetJournalEntryDetailsListAsync();

    public Task<JournalEntryDetail> GetJournalEntryDetailByIdAsync(int id);

    public Task<string> AddJournalEntryDetail(JournalEntryDetail JournalEntryDetail, List<int> contentDto, IFormFile? ImageFile, string? webRootPath);

    public Task<string> UpdateAsync(JournalEntryDetail JournalEntryDetail);

    public Task<string> DeleteAsync(JournalEntryDetail JournalEntryDetail);
  }
}
