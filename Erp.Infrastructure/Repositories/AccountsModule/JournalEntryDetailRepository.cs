using Erp.Data.Entities.AccountsModule;
using Erp.Infrastructure.Abstracts.AccountsModule;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.AccountsModule
{
  public class JournalEntryDetailRepository : GenericRepository<JournalEntryDetail>, IJournalEntryDetailRepository
  {
    private readonly DbSet<JournalEntryDetail> _JournalEntryDetails;
    public JournalEntryDetailRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _JournalEntryDetails = dbContext.Set<JournalEntryDetail>();
    }

    public Task<string> AddJournalEntryDetailAsync(JournalEntryDetail JournalEntryDetail)
    {
      throw new NotImplementedException();
    }

    public Task<JournalEntryDetail> GetJournalEntryDetailByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateJournalEntryDetailAsync(JournalEntryDetail request)
    {
      throw new NotImplementedException();
    }
  }
}
