using Erp.Data.Entities;
using Name.Data.Entities;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts
{
  public interface IReceivingVoucherRepository : IGenericRepository<ReceivingVoucher>
  {
    public Task<string> AddReceivingVoucherAsync(ReceivingVoucher ReceivingVoucher);

    public Task<ReceivingVoucher> GetReceivingVoucherByIdAsync(int id);

    public Task<string> UpdateReceivingVoucherAsync(ReceivingVoucher request);
  }
}
