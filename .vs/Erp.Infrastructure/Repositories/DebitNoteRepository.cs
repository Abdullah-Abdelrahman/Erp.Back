using Erp.Data.Entities;
using Erp.Infrastructure.Abstracts;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories
{
  public class DebitNoteRepository : GenericRepository<DebitNote>, IDebitNoteRepository
  {
    private readonly DbSet<DebitNote> _DebitNotes;
    public DebitNoteRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _DebitNotes = dbContext.Set<DebitNote>();
    }

    public Task<string> AddDebitNoteAsync(DebitNote DebitNote)
    {
      throw new NotImplementedException();
    }

    public Task<DebitNote> GetDebitNoteByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateDebitNoteAsync(DebitNote request)
    {
      throw new NotImplementedException();
    }
  }
}
