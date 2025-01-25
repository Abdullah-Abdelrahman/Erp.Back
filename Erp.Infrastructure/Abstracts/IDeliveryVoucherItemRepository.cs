using Erp.Data.Entities;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts
{
  public interface IDeliveryVoucherItemRepository : IGenericRepository<DeliveryVoucherItem>
  {
    public Task<string> AddDeliveryVoucherItemAsync(DeliveryVoucherItem DeliveryVoucherItem);

    public Task<DeliveryVoucherItem> GetDeliveryVoucherItemByIdAsync(int id);

    public Task<string> UpdateDeliveryVoucherItemAsync(DeliveryVoucherItem request);
  }
}
