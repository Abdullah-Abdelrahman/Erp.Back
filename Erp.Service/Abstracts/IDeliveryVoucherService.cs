using Erp.Data.Dto.DeliveryVoucher;
using Erp.Data.Entities.InventoryModule;

namespace Erp.Service.Abstracts
{
  public interface IDeliveryVoucherService
  {

    public Task<List<GetDeliveryVoucherByIdDto>> GetDeliveryVouchersListAsync();

    public Task<GetDeliveryVoucherByIdDto> GetDeliveryVoucherByIdAsync(int id);

    public Task<string> AddDeliveryVoucherAsync(AddDeliveryVoucherRequest addDeliveryVoucherRequestMapper, int VoucherStatusId = 1);
    public Task<string> UpdateAsync(UpdateDeliveryVoucherRequest DeliveryVoucher);

    public Task<string> DeleteAsync(DeliveryVoucher DeliveryVoucher);


    public Task<string> DeleteByIdAsync(int id);

    public Task<string> ConfirmDeliveryVoucherAsync(int DeliveryVoucherId);

    public Task<string> RejectDeliveryVoucherAsync(int DeliveryVoucherId);

  }
}
