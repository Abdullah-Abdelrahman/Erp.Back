using Erp.Data.Entities.InventoryModule;

namespace Erp.Service.Abstracts.InventoryModule
{
  public interface IPriceListService
  {
    public Task<List<PriceList>> GetPriceListsListAsync();

    public Task<PriceList> GetPriceListByIdAsync(int id);

    public Task<string> AddPriceListAsync(PriceList PriceList);

    public Task<string> AddPriceListItemAsync(PriceListItem Item);

    public Task<string> UpdateAsync(PriceList PriceList);

    public Task<string> DeleteAsync(PriceList PriceList);
  }
}
