using Erp.Data.Entities.InventoryModule;
using Name.Data.Entities;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts
{
  public interface ITransformVoucherRepository : IGenericRepository<TransformVoucher>
  {
    public Task<string> AddTransformVoucherAsync(TransformVoucher TransformVoucher);

    public Task<TransformVoucher> GetTransformVoucherByIdAsync(int id);

    public Task<string> UpdateTransformVoucherAsync(TransformVoucher request);
  }
}
