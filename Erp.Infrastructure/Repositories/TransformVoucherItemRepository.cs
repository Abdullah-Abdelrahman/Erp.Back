using Erp.Data.Entities;
using Erp.Infrastructure.Abstracts;
using Microsoft.EntityFrameworkCore;
using Name.Data.Entities;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories
{
  public class TransformVoucherItemRepository : GenericRepository<TransformVoucherItem>, ITransformVoucherItemRepository
  {
    private readonly DbSet<TransformVoucherItem> _TransformVoucherItems;
    public TransformVoucherItemRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _TransformVoucherItems = dbContext.Set<TransformVoucherItem>();
    }

    public Task<string> AddTransformVoucherItemAsync(TransformVoucherItem TransformVoucherItem)
    {
      throw new NotImplementedException();
    }

    public Task<TransformVoucherItem> GetTransformVoucherItemByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateTransformVoucherItemAsync(TransformVoucherItem request)
    {
      throw new NotImplementedException();
    }
  }


}
