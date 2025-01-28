using Erp.Data.Entities.AccountsModule;
using Erp.Service.Abstracts.AccountsModule;
using Microsoft.AspNetCore.Http;

namespace Erp.Service.Implementations.AccountsModule
{
  public class JournalEntryDetailService : IJournalEntryDetailService
  {
    public Task<string> AddJournalEntryDetail(JournalEntryDetail JournalEntryDetail, List<int> contentDto, IFormFile? ImageFile, string? webRootPath)
    {
      throw new NotImplementedException();
    }

    public Task<string> DeleteAsync(JournalEntryDetail JournalEntryDetail)
    {
      throw new NotImplementedException();
    }

    public Task<JournalEntryDetail> GetJournalEntryDetailByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<List<JournalEntryDetail>> GetJournalEntryDetailsListAsync()
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateAsync(JournalEntryDetail JournalEntryDetail)
    {
      throw new NotImplementedException();
    }
  }
}
