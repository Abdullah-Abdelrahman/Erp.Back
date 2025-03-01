using Erp.Data.Entities.HumanResources.Staff;
using Erp.Infrastructure.Abstracts.MainModule;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.MainModule
{
  public class ApplicationRoleRepository : GenericRepository<ApplicationRole>, IApplicationRoleRepository
  {
    private readonly DbSet<ApplicationRole> _applicationRoles;
    public ApplicationRoleRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _applicationRoles = dbContext.Set<ApplicationRole>();
    }

    public async Task<ApplicationRole> GetByIdAsync(string id)
    {
      return await _applicationRoles.FindAsync(id);
    }
  }
}
