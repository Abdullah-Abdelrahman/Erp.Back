using Erp.Data.Entities.PurchasesModule;
using Microsoft.AspNetCore.Http;

namespace Erp.Service.Abstracts
{
  public interface IDebitNoteItemService
  {
    public Task<List<DebitNoteItem>> GetDebitNoteItemsListAsync();

    public Task<DebitNoteItem> GetDebitNoteItemByIdAsync(int id);

    public Task<string> AddDebitNoteItem(DebitNoteItem DebitNoteItem, List<int> contentDto, IFormFile? ImageFile, string? webRootPath);

    public Task<string> UpdateAsync(DebitNoteItem DebitNoteItem);

    public Task<string> DeleteAsync(DebitNoteItem DebitNoteItem);
  }
}
