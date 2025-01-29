using Erp.Data.Dto.DebitNote;
using Erp.Data.Entities.PurchasesModule;

namespace Erp.Service.Abstracts
{
  public interface IDebitNoteService
  {
    public Task<List<GetDebitNoteByIdDto>> GetDebitNotesListAsync();

    public Task<GetDebitNoteByIdDto> GetDebitNoteByIdAsync(int id);

    public Task<string> AddDebitNote(AddDebitNoteRequest DebitNote);

    public Task<string> UpdateAsync(UpdateDebitNoteRequest DebitNote);

    public Task<string> DeleteAsync(DebitNote DebitNote);
    public Task<string> DeleteByIdAsync(int id);
  }
}
