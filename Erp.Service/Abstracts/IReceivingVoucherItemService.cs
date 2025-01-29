using Erp.Data.Entities.InventoryModule;
using Microsoft.AspNetCore.Http;

namespace Erp.Service.Abstracts
{
  public interface IReceivingVoucherItemService
  {

    public Task<List<ReceivingVoucherItem>> GetReceivingVoucherItemsListAsync();

    public Task<ReceivingVoucherItem> GetReceivingVoucherItemByIdAsync(int id);

    public Task<string> AddReceivingVoucherItem(ReceivingVoucherItem ReceivingVoucherItem, List<int> contentDto, IFormFile? ImageFile, string? webRootPath);

    public Task<string> UpdateAsync(ReceivingVoucherItem ReceivingVoucherItem);

    public Task<string> DeleteAsync(ReceivingVoucherItem ReceivingVoucherItem);
  }
}
