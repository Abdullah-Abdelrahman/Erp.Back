using Erp.Data.Entities;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts
{
  public interface IDebitNoteItemRepository : IGenericRepository<DebitNoteItem>
  {
    public Task<string> AddDebitNoteItemAsync(DebitNoteItem DebitNoteItem);

    public Task<DebitNoteItem> GetDebitNoteItemByIdAsync(int id);

    public Task<string> UpdateDebitNoteItemAsync(DebitNoteItem request);
  }
}
