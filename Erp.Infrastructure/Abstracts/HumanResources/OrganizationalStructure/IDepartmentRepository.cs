using Erp.Data.Entities.HumanResources.OrganizationalStructure;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.HumanResources.OrganizationalStructure
{
  public interface IDepartmentRepository : IGenericRepository<Department>
  {
    public Task<string> AddDepartmentAsync(Department Department);

    public Task<Department?> GetDepartmentByIdAsync(int id);

    public Task<List<Department>> GetDepartmentsListAsync();

    public Task<string> UpdateDepartmentAsync(Department request);
  }
}
