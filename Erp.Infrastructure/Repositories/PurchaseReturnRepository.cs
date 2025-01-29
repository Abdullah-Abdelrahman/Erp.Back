using Erp.Data.Entities.PurchasesModule;
using Erp.Infrastructure.Abstracts;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories
{
  public class PurchaseReturnRepository : GenericRepository<PurchaseReturn>, IPurchaseReturnRepository
  {
    private readonly DbSet<PurchaseReturn> _PurchaseReturns;
    public PurchaseReturnRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _PurchaseReturns = dbContext.Set<PurchaseReturn>();
    }

    public Task<string> AddPurchaseReturnAsync(PurchaseReturn PurchaseReturn)
    {
      throw new NotImplementedException();
    }

    public Task<PurchaseReturn> GetPurchaseReturnByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdatePurchaseReturnAsync(PurchaseReturn request)
    {
      throw new NotImplementedException();
    }
  }
}
