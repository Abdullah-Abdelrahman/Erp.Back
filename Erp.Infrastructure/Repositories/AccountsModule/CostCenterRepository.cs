using Erp.Data.Entities.AccountsModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.CostCentersModule;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.CostCentersModule
{
  public class CostCenterRepository<TCostCenter> : GenericRepository<TCostCenter>, ICostCenterRepository<TCostCenter> where TCostCenter : CostCenter
  {
    private readonly DbSet<TCostCenter> _CostCenters;

    public CostCenterRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _CostCenters = dbContext.Set<TCostCenter>();
    }

    public async Task<string> AddCostCenterAsync(TCostCenter CostCenter)
    {
      await _CostCenters.AddAsync(CostCenter);
      await _dbContext.SaveChangesAsync(); // Ensure changes are saved

      return MessageCenter.CrudMessage.Success;
    }

    public async Task<TCostCenter?> GetCostCenterByIdAsync(int id)
    {
      return await _CostCenters.FindAsync(id);
    }

    public async Task<List<TCostCenter>> GetCostCentersListAsync()
    {
      return await _CostCenters.ToListAsync();
    }

    public async Task<string> UpdateCostCenterAsync(TCostCenter CostCenter)
    {
      _CostCenters.Update(CostCenter);
      await _dbContext.SaveChangesAsync();

      return MessageCenter.CrudMessage.Success;
    }

    public async Task<List<T>> GetCostCentersByTypeAsync<T>() where T : CostCenter
    {
      return await _CostCenters.OfType<T>().ToListAsync();
    }

  }
}
