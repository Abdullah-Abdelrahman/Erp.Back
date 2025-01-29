using Erp.Data.Entities.InventoryModule;
using Erp.Infrastructure.Abstracts;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories
{
  public class DeliveryVoucherItemRepository : GenericRepository<DeliveryVoucherItem>, IDeliveryVoucherItemRepository
  {
    private readonly DbSet<DeliveryVoucherItem> _DeliveryVoucherItems;
    public DeliveryVoucherItemRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _DeliveryVoucherItems = dbContext.Set<DeliveryVoucherItem>();
    }

    public Task<string> AddDeliveryVoucherItemAsync(DeliveryVoucherItem DeliveryVoucherItem)
    {
      throw new NotImplementedException();
    }

    public Task<DeliveryVoucherItem> GetDeliveryVoucherItemByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateDeliveryVoucherItemAsync(DeliveryVoucherItem request)
    {
      throw new NotImplementedException();
    }
  }
}
