using Erp.Data.Entities.HumanResources.Staff;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.MainModule
{
  public interface IApplicationRoleRepository : IGenericRepository<ApplicationRole>
  {

    Task<ApplicationRole> GetByIdAsync(string id);
  }
}
