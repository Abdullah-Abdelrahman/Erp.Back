using Erp.Data.Entities.InventoryModule;
using Erp.Infrastructure.Abstracts;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories
{
  public class ReceivingVoucherRepository : GenericRepository<ReceivingVoucher>, IReceivingVoucherRepository
  {
    private readonly DbSet<ReceivingVoucher> _ReceivingVouchers;
    public ReceivingVoucherRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _ReceivingVouchers = dbContext.Set<ReceivingVoucher>();
    }

    public Task<string> AddReceivingVoucherAsync(ReceivingVoucher ReceivingVoucher)
    {
      throw new NotImplementedException();
    }

    public Task<ReceivingVoucher> GetReceivingVoucherByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateReceivingVoucherAsync(ReceivingVoucher request)
    {
      throw new NotImplementedException();
    }
  }
}
