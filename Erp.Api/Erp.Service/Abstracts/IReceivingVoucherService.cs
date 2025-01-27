using Erp.Data.Dto.ReceivingVoucher;
using Erp.Data.Entities;

namespace Erp.Service.Abstracts
{
  public interface IReceivingVoucherService
  {

    public Task<List<GetReceivingVoucherByIdDto>> GetReceivingVouchersListAsync();

    public Task<GetReceivingVoucherByIdDto> GetReceivingVoucherByIdAsync(int id);

    public Task<string> AddReceivingVoucher(AddReceivingVoucherRequest ReceivingVoucher);

    public Task<string> UpdateAsync(UpdateReceivingVoucherRequest ReceivingVoucher);

    public Task<string> DeleteAsync(ReceivingVoucher ReceivingVoucher);
    public Task<string> DeleteByIdAsync(int id);
  }
}
