using Erp.Data.Entities;
using Erp.Service.Abstracts;
using Microsoft.AspNetCore.Http;

namespace Erp.Service.Implementations
{
  public class ReceivingVoucherItemService : IReceivingVoucherItemService
  {
    public Task<string> AddReceivingVoucherItem(ReceivingVoucherItem ReceivingVoucherItem, List<int> contentDto, IFormFile? ImageFile, string? webRootPath)
    {
      throw new NotImplementedException();
    }

    public Task<string> DeleteAsync(ReceivingVoucherItem ReceivingVoucherItem)
    {
      throw new NotImplementedException();
    }

    public Task<ReceivingVoucherItem> GetReceivingVoucherItemByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<List<ReceivingVoucherItem>> GetReceivingVoucherItemsListAsync()
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateAsync(ReceivingVoucherItem ReceivingVoucherItem)
    {
      throw new NotImplementedException();
    }
  }


}
