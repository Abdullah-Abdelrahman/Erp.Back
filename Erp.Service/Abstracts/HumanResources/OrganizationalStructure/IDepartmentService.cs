using Erp.Data.Entities.HumanResources.OrganizationalStructure;

namespace Erp.Service.Abstracts.HumanResources.OrganizationalStructure
{
  public interface IDepartmentService
  {
    public Task<List<Department>> GetDepartmentsListAsync();

    public Task<Department> GetDepartmentByIdAsync(int id);

    public Task<string> AddDepartmentAsync(Department Department);

    public Task<string> UpdateAsync(Department Department);

    public Task<string> DeleteAsync(Department Department);
  }
}
