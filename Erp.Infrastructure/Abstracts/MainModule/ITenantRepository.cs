using Erp.Data.Entities.MainModule;

namespace Erp.Infrastructure.Abstracts.MainModule
{
  public interface ITenantRepository
  {
    public Task<Tenant> AddAsync(Tenant entity);
    public Task DeleteAsync(Tenant entity);
    public Task<Tenant> GetByIdAsync(string id);
    public Task UpdateAsync(Tenant entity);
  }
}
