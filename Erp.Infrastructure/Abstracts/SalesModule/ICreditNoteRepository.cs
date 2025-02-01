using Erp.Data.Entities.SalesModule;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.SalesModule
{
  public interface ICreditNoteRepository : IGenericRepository<CreditNote>
  {
    public Task<string> AddCreditNoteAsync(CreditNote CreditNote);

    public Task<CreditNote> GetCreditNoteByIdAsync(int id);

    public Task<string> UpdateCreditNoteAsync(CreditNote request);
  }
}
