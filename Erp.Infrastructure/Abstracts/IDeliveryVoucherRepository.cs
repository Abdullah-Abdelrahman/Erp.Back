using Erp.Data.Entities.InventoryModule;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts
{
  public interface IDeliveryVoucherRepository : IGenericRepository<DeliveryVoucher>
  {
    public Task<string> AddDeliveryVoucherAsync(DeliveryVoucher DeliveryVoucher);

    public Task<DeliveryVoucher> GetDeliveryVoucherByIdAsync(int id);

    public Task<string> UpdateDeliveryVoucherAsync(DeliveryVoucher request);
  }
}
