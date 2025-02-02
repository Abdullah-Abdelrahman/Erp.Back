using Erp.Data.Entities.InventoryModule;
using Erp.Service.Abstracts;
using Microsoft.AspNetCore.Http;

namespace Erp.Service.Implementations
{
  public class TransformVoucherItemService : ITransformVoucherItemService
  {
    public Task<string> AddTransformVoucherItem(TransformVoucherItem TransformVoucherItem, List<int> contentDto, IFormFile? ImageFile, string? webRootPath)
    {
      throw new NotImplementedException();
    }

    public Task<string> DeleteAsync(TransformVoucherItem TransformVoucherItem)
    {
      throw new NotImplementedException();
    }

    public Task<TransformVoucherItem> GetTransformVoucherItemByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<List<TransformVoucherItem>> GetTransformVoucherItemsListAsync()
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateAsync(TransformVoucherItem TransformVoucherItem)
    {
      throw new NotImplementedException();
    }
  }
}
