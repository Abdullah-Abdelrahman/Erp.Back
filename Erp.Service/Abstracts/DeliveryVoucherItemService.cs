using Erp.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace Erp.Service.Abstracts
{
  public interface IDeliveryVoucherItemService
  {

    public Task<List<DeliveryVoucherItem>> GetDeliveryVoucherItemsListAsync();

    public Task<DeliveryVoucherItem> GetDeliveryVoucherItemByIdAsync(int id);

    public Task<string> AddDeliveryVoucherItem(DeliveryVoucherItem DeliveryVoucherItem, List<int> contentDto, IFormFile? ImageFile, string? webRootPath);

    public Task<string> UpdateAsync(DeliveryVoucherItem DeliveryVoucherItem);

    public Task<string> DeleteAsync(DeliveryVoucherItem DeliveryVoucherItem);
  }
}
