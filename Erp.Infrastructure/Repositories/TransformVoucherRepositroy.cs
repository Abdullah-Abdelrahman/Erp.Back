using Erp.Data.Entities.InventoryModule;
using Erp.Infrastructure.Abstracts;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories
{
  public class TransformVoucherRepository : GenericRepository<TransformVoucher>, ITransformVoucherRepository
  {
    private readonly DbSet<TransformVoucher> _TransformVouchers;
    public TransformVoucherRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _TransformVouchers = dbContext.Set<TransformVoucher>();
    }

    public Task<string> AddTransformVoucherAsync(TransformVoucher TransformVoucher)
    {
      throw new NotImplementedException();
    }

    public Task<TransformVoucher> GetTransformVoucherByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateTransformVoucherAsync(TransformVoucher request)
    {
      throw new NotImplementedException();
    }
  }


}
