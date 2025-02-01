using Erp.Data.Entities.SalesModule;
using Microsoft.AspNetCore.Http;

namespace Erp.Service.Abstracts.SalesModule
{
  public interface ICreditNoteItemService
  {
    public Task<List<CreditNoteItem>> GetCreditNoteItemsListAsync();

    public Task<CreditNoteItem> GetCreditNoteItemByIdAsync(int id);

    public Task<string> AddCreditNoteItem(CreditNoteItem CreditNoteItem, List<int> contentDto, IFormFile? ImageFile, string? webRootPath);

    public Task<string> UpdateAsync(CreditNoteItem CreditNoteItem);

    public Task<string> DeleteAsync(CreditNoteItem CreditNoteItem);
  }
}
