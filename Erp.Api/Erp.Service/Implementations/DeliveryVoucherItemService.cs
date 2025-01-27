using Erp.Data.Entities;
using Erp.Service.Abstracts;
using Microsoft.AspNetCore.Http;

namespace Erp.Service.Implementations
{
  public class DeliveryVoucherItemService : IDeliveryVoucherItemService
  {
    public Task<string> AddDeliveryVoucherItem(DeliveryVoucherItem DeliveryVoucherItem, List<int> contentDto, IFormFile? ImageFile, string? webRootPath)
    {
      throw new NotImplementedException();
    }

    public Task<string> DeleteAsync(DeliveryVoucherItem DeliveryVoucherItem)
    {
      throw new NotImplementedException();
    }

    public Task<DeliveryVoucherItem> GetDeliveryVoucherItemByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<List<DeliveryVoucherItem>> GetDeliveryVoucherItemsListAsync()
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateAsync(DeliveryVoucherItem DeliveryVoucherItem)
    {
      throw new NotImplementedException();
    }
  }


}
