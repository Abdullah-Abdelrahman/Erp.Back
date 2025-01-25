using Erp.Data.Dto.TransformVoucher;
using Erp.Data.Dto.TransformVoucher.cs;
using Erp.Data.Entities;

namespace Erp.Service.Abstracts
{
  public interface ITransformVoucherService
  {

    public Task<List<GetTransformVoucherByIdDto>> GetTransformVouchersListAsync();

    public Task<GetTransformVoucherByIdDto> GetTransformVoucherByIdAsync(int id);

    public Task<string> AddTransformVoucher(AddTransformVoucherRequest TransformVoucher);

    public Task<string> UpdateAsync(UpdateTransformVoucherRequest TransformVoucher);

    public Task<string> DeleteAsync(TransformVoucher TransformVoucher);
    public Task<string> DeleteByIdAsync(int id);
  }
}
