using Erp.Data.Entities.InventoryModule;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts
{
  public interface ITransformVoucherItemRepository : IGenericRepository<TransformVoucherItem>
  {
    public Task<string> AddTransformVoucherItemAsync(TransformVoucherItem TransformVoucherItem);

    public Task<TransformVoucherItem> GetTransformVoucherItemByIdAsync(int id);

    public Task<string> UpdateTransformVoucherItemAsync(TransformVoucherItem request);
  }
}
