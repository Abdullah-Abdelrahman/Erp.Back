using Erp.Data.Entities.AccountsModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.AccountsModule;
using Erp.Infrastructure.Abstracts.CostCentersModule;
using Erp.Service.Abstracts.CostCentersModule;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations.CostCentersModule
{
  public class CostCenterService : ICostCenterService
  {
    private readonly ICostCenterRepository<CostCenter> _CostCenterRepository;
    private readonly ICostCenterRepository<PrimaryCostCenter> _primaryCostCenterRepository;
    private readonly ICostCenterRepository<SecondaryCostCenter> _secondaryCostCenterRepository;

    private readonly IJournalEntryDetailRepository _JournalEntryDetailRepository;


    // Constructor that injects the repository
    public CostCenterService(
      ICostCenterRepository<CostCenter> CostCenterRepository,
      ICostCenterRepository<PrimaryCostCenter> primaryCostCenterRepository,
      ICostCenterRepository<SecondaryCostCenter> secondaryCostCenterRepository,
            IJournalEntryDetailRepository journalEntryDetailRepository)
    {
      _CostCenterRepository = CostCenterRepository;

      _primaryCostCenterRepository = primaryCostCenterRepository;
      _secondaryCostCenterRepository = secondaryCostCenterRepository;
      _JournalEntryDetailRepository = journalEntryDetailRepository;
    }

    public async Task<string> AddCostCenterAsync(CostCenter CostCenter)
    {
      try
      {
        return await _CostCenterRepository.AddCostCenterAsync(CostCenter);
      }
      catch
      {
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<PrimaryCostCenter?> GetPrimaryCostCenterByIdAsync(int id)
    {
      try
      {
        var result = await _primaryCostCenterRepository.GetTableNoTracking().Where(x => x.CostCenterId == id).SingleOrDefaultAsync();

        result.costCenters = await _CostCenterRepository.GetTableNoTracking().Where(x => x.ParentCostCenterID == result.CostCenterId).ToListAsync();
        return result;
      }
      catch
      {
        return null;
      }
    }


    public async Task<string> UpdateCostCenterAsync(CostCenter CostCenter)
    {
      try
      {
        return await _CostCenterRepository.UpdateCostCenterAsync(CostCenter);
      }
      catch
      {
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<string> DeleteCostCenterAsync(int id)
    {
      try
      {
        var CostCenter = await _CostCenterRepository.GetCostCenterByIdAsync(id);
        if (CostCenter != null)
        {
          // Deleting the CostCenter (or you could add extra logic here)
          // Ideally, you'd add a Delete method in the repository if needed
          return await _CostCenterRepository.UpdateCostCenterAsync(CostCenter);
        }
        return MessageCenter.CrudMessage.DoesNotExist;
      }
      catch
      {
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<List<T>> GetCostCentersByTypeAsync<T>() where T : CostCenter
    {
      try
      {
        return await _CostCenterRepository.GetCostCentersByTypeAsync<T>();
      }
      catch
      {
        return new List<T>();
      }
    }

    public async Task<string> GetCostCenterTypeByIdAsync(int CostCenterId)
    {
      var primaryCostCenter = await _primaryCostCenterRepository.GetCostCenterByIdAsync(CostCenterId);
      if (primaryCostCenter != null) return "Primary";

      var secondaryCostCenter = await _secondaryCostCenterRepository.GetCostCenterByIdAsync(CostCenterId);
      if (secondaryCostCenter != null) return "Secondary";

      return "Unknown";
    }

    public async Task<SecondaryCostCenter?> GetSecondaryCostCenterByIdAsync(int id)
    {
      try
      {
        var result = await _secondaryCostCenterRepository.GetTableNoTracking().Where(x => x.CostCenterId == id).Include(x => x.journalEntryDetails).SingleOrDefaultAsync();

        result.journalEntryDetails = await _JournalEntryDetailRepository.GetTableNoTracking().Where(x => x.CostCenterId == result.CostCenterId).Include(x => x.CostCenter).Include(x => x.CostCenter).ToListAsync();


        return result;
      }
      catch
      {
        return null;
      }
    }

    public async Task<List<PrimaryCostCenter>> GetMainCostCenterListAsync()
    {
      try
      {
        var result = await _primaryCostCenterRepository.GetTableNoTracking().Where(x => x.ParentCostCenterID == null).Include(x => x.costCenters).ToListAsync();


        foreach (var primaryCostCenter in result)
        {
          primaryCostCenter.costCenters = await _CostCenterRepository.GetTableNoTracking().Where(x => x.ParentCostCenterID == primaryCostCenter.CostCenterId).ToListAsync();
        }

        return result;
      }
      catch
      {
        return null;
      }
    }

    public async Task<CostCenter?> GetCostCenterByIdAsync(int id)
    {
      return await _CostCenterRepository.GetByIdAsync(id);
    }

    public async Task<List<PrimaryCostCenter>> GetPrimaryCostCenterListAsync()
    {
      var result = await _primaryCostCenterRepository.GetTableNoTracking().ToListAsync();

      return result;
    }

    public async Task<List<SecondaryCostCenter>> GetSecondaryCostCenterListAsync()
    {
      var result = await _secondaryCostCenterRepository.GetTableNoTracking().ToListAsync();

      return result;
    }
  }
}
