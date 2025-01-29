using Erp.Data.Entities.InventoryModule;
using Microsoft.AspNetCore.Http;

namespace Erp.Service.Abstracts
{
  public interface ITransformVoucherItemService
  {

    public Task<List<TransformVoucherItem>> GetTransformVoucherItemsListAsync();

    public Task<TransformVoucherItem> GetTransformVoucherItemByIdAsync(int id);

    public Task<string> AddTransformVoucherItem(TransformVoucherItem TransformVoucherItem, List<int> contentDto, IFormFile? ImageFile, string? webRootPath);

    public Task<string> UpdateAsync(TransformVoucherItem TransformVoucherItem);

    public Task<string> DeleteAsync(TransformVoucherItem TransformVoucherItem);
  }
}
