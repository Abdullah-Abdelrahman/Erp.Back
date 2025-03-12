using Erp.Data.Entities.InventoryModule;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.InventoryModule
{
  public interface IPriceListRepository : IGenericRepository<PriceList>
  {
    public Task<string> AddPriceListAsync(PriceList PriceList);

    public Task<PriceList> GetPriceListByIdAsync(int id);

    public Task<string> UpdatePriceListAsync(PriceList request);
  }
}
