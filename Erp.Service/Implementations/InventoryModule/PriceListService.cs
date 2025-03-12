using Erp.Data.Entities.InventoryModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.InventoryModule;
using Erp.Service.Abstracts.InventoryModule;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations.InventoryModule
{
  public class PriceListService : IPriceListService
  {
    private readonly IPriceListRepository _PriceListRepository;


    public PriceListService(IPriceListRepository PriceListRepository)
    {
      _PriceListRepository = PriceListRepository;

    }
    public async Task<string> AddPriceListAsync(PriceList PriceList)
    {


      var newPriceList = await _PriceListRepository.AddAsync(PriceList);
      if (newPriceList != null)
      {
        return MessageCenter.CrudMessage.Success;
      }
      else
      {
        return "Somthing bad happend :";
      }
    }
    public async Task<string> AddPriceListItemAsync(PriceListItem Item)
    {
      var priceList = await _PriceListRepository.GetTableAsTracking().Where(x => x.Id == Item.PriceListId).SingleOrDefaultAsync();
      var transact = _PriceListRepository.BeginTransaction();
      try
      {

        priceList.priceListItems.Add(Item);
        await _PriceListRepository.UpdateAsync(priceList);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch (Exception ex)
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied + ex.Message;
      }


    }
    public async Task<string> DeleteAsync(PriceList PriceList)
    {
      try
      {
        await _PriceListRepository.DeleteAsync(PriceList);
        return MessageCenter.CrudMessage.Success;
      }
      catch (Exception ex)
      {
        return "There is a problem in deleteing the PriceList : " + ex.Message;
      }

    }

    public async Task<PriceList> GetPriceListByIdAsync(int id)
    {
      var PriceList = await _PriceListRepository.GetTableNoTracking().Where(x => x.Id == id).Include(x => x.priceListItems).ThenInclude(p => p.Product).SingleOrDefaultAsync();

      return PriceList;
    }

    public async Task<List<PriceList>> GetPriceListsListAsync()
    {
      var PriceLists = await _PriceListRepository.GetTableNoTracking().Include(x => x.priceListItems).ToListAsync();

      return PriceLists;
    }

    public async Task<string> UpdateAsync(PriceList PriceList)
    {
      var transact = _PriceListRepository.BeginTransaction();
      try
      {
        await _PriceListRepository.UpdateAsync(PriceList);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch (Exception ex)
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied + ex.Message;
      }
    }
  }
}
