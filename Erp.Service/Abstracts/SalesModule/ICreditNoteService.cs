using Erp.Data.Dto.CreditNote;
using Erp.Data.Entities.SalesModule;

namespace Erp.Service.Abstracts.SalesModule
{
  public interface ICreditNoteService
  {
    public Task<List<GetCreditNoteByIdDto>> GetCreditNotesListAsync();

    public Task<GetCreditNoteByIdDto> GetCreditNoteByIdAsync(int id);

    public Task<string> AddCreditNote(AddCreditNoteRequest CreditNote);

    public Task<string> UpdateAsync(UpdateCreditNoteRequest CreditNote);

    public Task<string> DeleteAsync(CreditNote CreditNote);
    public Task<string> DeleteByIdAsync(int id);
  }
}
