using Erp.Data.Entities.SalesModule;
using Microsoft.AspNetCore.Http;

namespace Erp.Service.Abstracts.SalesModule
{
  public interface IQuotationItemService
  {
    public Task<List<QuotationItem>> GetQuotationItemsListAsync();

    public Task<QuotationItem> GetQuotationItemByIdAsync(int id);

    public Task<string> AddQuotationItem(QuotationItem QuotationItem, List<int> contentDto, IFormFile? ImageFile, string? webRootPath);

    public Task<string> UpdateAsync(QuotationItem QuotationItem);

    public Task<string> DeleteAsync(QuotationItem QuotationItem);
  }
}
