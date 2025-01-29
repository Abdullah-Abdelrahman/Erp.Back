using Erp.Data.Entities.InventoryModule;
using Erp.Infrastructure.Abstracts;
using Microsoft.EntityFrameworkCore;
using Name.Data.Entities;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories
{
  public class ReceivingVoucherItemRepository : GenericRepository<ReceivingVoucherItem>, IReceivingVoucherItemRepository
  {
    private readonly DbSet<ReceivingVoucherItem> _ReceivingVoucherItems;
    public ReceivingVoucherItemRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _ReceivingVoucherItems = dbContext.Set<ReceivingVoucherItem>();
    }

    public Task<string> AddReceivingVoucherItemAsync(ReceivingVoucherItem ReceivingVoucherItem)
    {
      throw new NotImplementedException();
    }

    public Task<ReceivingVoucherItem> GetReceivingVoucherItemByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateReceivingVoucherItemAsync(ReceivingVoucherItem request)
    {
      throw new NotImplementedException();
    }
  }
}
