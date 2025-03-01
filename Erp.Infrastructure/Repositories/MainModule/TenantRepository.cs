using Erp.Data.Entities.MainModule;
using Erp.Infrastructure.Abstracts.MainModule;
using Erp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Erp.Infrastructure.Repositories.MainModule
{
  public class TenantRepository : ITenantRepository
  {

    protected readonly TenantDBContext _tenantdbContext;

    public TenantRepository(TenantDBContext tenantdbContext)
    {
      _tenantdbContext = tenantdbContext;
    }
    public async Task<Tenant> AddAsync(Tenant entity)
    {
      await _tenantdbContext.Set<Tenant>().AddAsync(entity);
      await _tenantdbContext.SaveChangesAsync();

      return entity;
    }




    public IDbContextTransaction BeginTransaction()
    {
      return _tenantdbContext.Database.BeginTransaction();
    }



    public async Task DeleteAsync(Tenant entity)
    {
      _tenantdbContext.Set<Tenant>().Remove(entity);
      await _tenantdbContext.SaveChangesAsync();
    }



    public async Task<Tenant> GetByIdAsync(string id)
    {
      return await _tenantdbContext.Set<Tenant>().FindAsync(id);
    }

    public IQueryable<Tenant> GetTableAsTracking()
    {
      return _tenantdbContext.Set<Tenant>().AsQueryable();
    }

    public IQueryable<Tenant> GetTableNoTracking()
    {
      return _tenantdbContext.Set<Tenant>().AsNoTracking().AsQueryable();
    }



    public void Commit()
    {
      _tenantdbContext.Database.CommitTransaction();

    }

    public void RollBack()
    {
      _tenantdbContext.Database.RollbackTransaction();

    }


    public async Task SaveChangesAsync()
    {
      await _tenantdbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Tenant entity)
    {
      _tenantdbContext.Set<Tenant>().Update(entity);
      await _tenantdbContext.SaveChangesAsync();
    }




  }
}
