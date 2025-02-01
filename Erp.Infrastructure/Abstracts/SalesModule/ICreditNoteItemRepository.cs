using Erp.Data.Entities.SalesModule;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.SalesModule
{
  public interface ICreditNoteItemRepository : IGenericRepository<CreditNoteItem>
  {
    public Task<string> AddCreditNoteItemAsync(CreditNoteItem CreditNoteItem);

    public Task<CreditNoteItem> GetCreditNoteItemByIdAsync(int id);

    public Task<string> UpdateCreditNoteItemAsync(CreditNoteItem request);
  }
}
