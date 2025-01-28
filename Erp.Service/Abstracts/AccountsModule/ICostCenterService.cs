using Erp.Data.Entities.AccountsModule;

namespace Erp.Service.Abstracts.CostCentersModule
{
  public interface ICostCenterService
  {
    Task<string> AddCostCenterAsync(CostCenter CostCenter);


    Task<PrimaryCostCenter?> GetPrimaryCostCenterByIdAsync(int id);


    Task<SecondaryCostCenter?> GetSecondaryCostCenterByIdAsync(int id);

    Task<List<PrimaryCostCenter>> GetMainCostCenterListAsync();

    Task<string> UpdateCostCenterAsync(CostCenter CostCenter);


    Task<string> DeleteCostCenterAsync(int id);

    Task<List<T>> GetCostCentersByTypeAsync<T>() where T : CostCenter;

    Task<string> GetCostCenterTypeByIdAsync(int CostCenterId);

    Task<CostCenter?> GetCostCenterByIdAsync(int id);
  }
}
