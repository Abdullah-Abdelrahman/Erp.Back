using Erp.Data.Dto.DeliveryVoucher;
using Erp.Data.Entities.InventoryModule;

namespace Erp.Service.Abstracts
{
  public interface IDeliveryVoucherService
  {

    public Task<List<GetDeliveryVoucherByIdDto>> GetDeliveryVouchersListAsync();

    public Task<GetDeliveryVoucherByIdDto> GetDeliveryVoucherByIdAsync(int id);

    public Task<string> AddDeliveryVoucher(AddDeliveryVoucherRequest addDeliveryVoucherRequestMapper);
    public Task<string> UpdateAsync(UpdateDeliveryVoucherRequest DeliveryVoucher);

    public Task<string> DeleteAsync(DeliveryVoucher DeliveryVoucher);

    public Task<string> DeleteByIdAsync(int id);

  }
}
