using Erp.Data.Entities;
using Erp.Infrastructure.Abstracts;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories
{
  public class DeliveryVoucherRepository : GenericRepository<DeliveryVoucher>, IDeliveryVoucherRepository
  {
    private readonly DbSet<DeliveryVoucher> _DeliveryVouchers;
    public DeliveryVoucherRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _DeliveryVouchers = dbContext.Set<DeliveryVoucher>();
    }

    public Task<string> AddDeliveryVoucherAsync(DeliveryVoucher DeliveryVoucher)
    {
      throw new NotImplementedException();
    }

    public Task<DeliveryVoucher> GetDeliveryVoucherByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateDeliveryVoucherAsync(DeliveryVoucher request)
    {
      throw new NotImplementedException();
    }
  }
}
