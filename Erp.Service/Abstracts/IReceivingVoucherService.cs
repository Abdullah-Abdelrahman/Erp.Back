using Erp.Data.Dto.ReceivingVoucher;
using Erp.Data.Entities.InventoryModule;

namespace Erp.Service.Abstracts
{
  public interface IReceivingVoucherService
  {

    public Task<List<GetReceivingVoucherByIdDto>> GetReceivingVouchersListAsync();

    public Task<GetReceivingVoucherByIdDto> GetReceivingVoucherByIdAsync(int id);

    public Task<string> AddReceivingVoucherAsync(AddReceivingVoucherRequest ReceivingVoucher, int VoucherStatusId = 1);
    public Task<string> ConfirmReceivingVoucherAsync(int ReceivingVoucherId);
    public Task<string> RejectReceivingVoucherAsync(int ReceivingVoucherId);

    public Task<string> UpdateAsync(UpdateReceivingVoucherRequest ReceivingVoucher);

    public Task<string> DeleteAsync(ReceivingVoucher ReceivingVoucher);
    public Task<string> DeleteByIdAsync(int id);
  }
}
