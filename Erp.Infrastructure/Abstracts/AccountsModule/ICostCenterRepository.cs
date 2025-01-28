using Erp.Data.Entities.AccountsModule;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.CostCentersModule
{
  public interface ICostCenterRepository<TCostCenter> : IGenericRepository<TCostCenter> where TCostCenter : CostCenter
  {
    Task<string> AddCostCenterAsync(TCostCenter CostCenter);
    Task<TCostCenter?> GetCostCenterByIdAsync(int id);
    Task<List<TCostCenter>> GetCostCentersListAsync();
    Task<string> UpdateCostCenterAsync(TCostCenter CostCenter);
    Task<List<T>> GetCostCentersByTypeAsync<T>() where T : CostCenter;
  }
}
