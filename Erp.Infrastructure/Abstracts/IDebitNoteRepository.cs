using Erp.Data.Entities;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts
{
  public interface IDebitNoteRepository : IGenericRepository<DebitNote>
  {
    public Task<string> AddDebitNoteAsync(DebitNote DebitNote);

    public Task<DebitNote> GetDebitNoteByIdAsync(int id);

    public Task<string> UpdateDebitNoteAsync(DebitNote request);
  }
}
