using Erp.Data.Entities;
using Erp.Service.Abstracts;
using Microsoft.AspNetCore.Http;

namespace Erp.Service.Implementations
{
  public class DebitNoteItemService : IDebitNoteItemService
  {
    public Task<string> AddDebitNoteItem(DebitNoteItem DebitNoteItem, List<int> contentDto, IFormFile? ImageFile, string? webRootPath)
    {
      throw new NotImplementedException();
    }

    public Task<string> DeleteAsync(DebitNoteItem DebitNoteItem)
    {
      throw new NotImplementedException();
    }

    public Task<DebitNoteItem> GetDebitNoteItemByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<List<DebitNoteItem>> GetDebitNoteItemsListAsync()
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateAsync(DebitNoteItem DebitNoteItem)
    {
      throw new NotImplementedException();
    }
  }
}
