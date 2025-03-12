using Erp.Data.Entities.InventoryModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.InventoryModule;
using Erp.Service.Abstracts.InventoryModule;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations.InventoryModule
{
  public class StockTakingService : IStockTakingService
  {
    private readonly IStockTakingRepository _StockTakingRepository;


    public StockTakingService(IStockTakingRepository StockTakingRepository)
    {
      _StockTakingRepository = StockTakingRepository;

    }
    public async Task<string> AddStockTakingAsync(StockTaking StockTaking)
    {


      var newStockTaking = await _StockTakingRepository.AddAsync(StockTaking);
      if (newStockTaking != null)
      {
        return MessageCenter.CrudMessage.Success;
      }
      else
      {
        return "Somthing bad happend :";
      }
    }
    public async Task<string> AddStockTakingItemAsync(StockTakingItem Item)
    {
      var StockTaking = await _StockTakingRepository.GetTableAsTracking().Where(x => x.Id == Item.StockTakingId).SingleOrDefaultAsync();
      var transact = _StockTakingRepository.BeginTransaction();
      try
      {

        StockTaking.stockTakingItems.Add(Item);
        await _StockTakingRepository.UpdateAsync(StockTaking);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch (Exception ex)
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied + ex.Message;
      }


    }
    public async Task<string> DeleteAsync(StockTaking StockTaking)
    {
      try
      {
        await _StockTakingRepository.DeleteAsync(StockTaking);
        return MessageCenter.CrudMessage.Success;
      }
      catch (Exception ex)
      {
        return "There is a problem in deleteing the StockTaking : " + ex.Message;
      }

    }

    public async Task<StockTaking> GetStockTakingByIdAsync(int id)
    {
      var StockTaking = await _StockTakingRepository.GetTableNoTracking().Where(x => x.Id == id).Include(x => x.stockTakingItems).ThenInclude(p => p.Product).SingleOrDefaultAsync();

      return StockTaking;
    }

    public async Task<List<StockTaking>> GetStockTakingsListAsync()
    {
      var StockTakings = await _StockTakingRepository.GetTableNoTracking().Include(x => x.stockTakingItems).ToListAsync();

      return StockTakings;
    }

    public async Task<string> UpdateAsync(StockTaking StockTaking)
    {
      var transact = _StockTakingRepository.BeginTransaction();
      try
      {
        await _StockTakingRepository.UpdateAsync(StockTaking);

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
