using Erp.Data.Entities.InventoryModule;
using Name.Data.Entities;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts
{
  public interface IReceivingVoucherItemRepository : IGenericRepository<ReceivingVoucherItem>
  {
    public Task<string> AddReceivingVoucherItemAsync(ReceivingVoucherItem ReceivingVoucherItem);

    public Task<ReceivingVoucherItem> GetReceivingVoucherItemByIdAsync(int id);

    public Task<string> UpdateReceivingVoucherItemAsync(ReceivingVoucherItem request);
  }
}
