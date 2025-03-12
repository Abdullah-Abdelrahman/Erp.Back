using Erp.Data.Entities.InventoryModule;
using Erp.Infrastructure.Abstracts.InventoryModule;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.InventoryModule
{
  public class VoucherStatusRepository : GenericRepository<VoucherStatus>, IVoucherStatusRepository
  {
    private readonly DbSet<VoucherStatus> _voucherStatuses;
    public VoucherStatusRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _voucherStatuses = dbContext.Set<VoucherStatus>();
    }
  }
}
