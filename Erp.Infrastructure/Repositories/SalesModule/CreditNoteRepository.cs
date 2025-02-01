using Erp.Data.Entities.SalesModule;
using Erp.Infrastructure.Abstracts.SalesModule;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.SalesModule
{
  public class CreditNoteRepository : GenericRepository<CreditNote>, ICreditNoteRepository
  {
    private readonly DbSet<CreditNote> _CreditNotes;
    public CreditNoteRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _CreditNotes = dbContext.Set<CreditNote>();
    }

    public Task<string> AddCreditNoteAsync(CreditNote CreditNote)
    {
      throw new NotImplementedException();
    }

    public Task<CreditNote> GetCreditNoteByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateCreditNoteAsync(CreditNote request)
    {
      throw new NotImplementedException();
    }
  }
}
