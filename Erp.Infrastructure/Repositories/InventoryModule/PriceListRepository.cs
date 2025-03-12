using Erp.Data.Entities.InventoryModule;
using Erp.Infrastructure.Abstracts.InventoryModule;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.InventoryModule
{
  public class PriceListRepository : GenericRepository<PriceList>, IPriceListRepository
  {
    private readonly DbSet<PriceList> _PriceLists;
    public PriceListRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _PriceLists = dbContext.Set<PriceList>();
    }

    public Task<string> AddPriceListAsync(PriceList PriceList)
    {
      throw new NotImplementedException();
    }

    public Task<PriceList> GetPriceListByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdatePriceListAsync(PriceList request)
    {
      throw new NotImplementedException();
    }
  }
}
