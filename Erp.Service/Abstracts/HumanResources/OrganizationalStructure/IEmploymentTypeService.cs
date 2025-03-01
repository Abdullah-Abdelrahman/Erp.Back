using Erp.Data.Entities.HumanResources.OrganizationalStructure;

namespace Erp.Service.Abstracts.HumanResources.OrganizationalStructure
{
  public interface IEmploymentTypeService
  {
    public Task<List<EmploymentType>> GetEmploymentTypesListAsync();

    public Task<EmploymentType> GetEmploymentTypeByIdAsync(int id);

    public Task<string> AddEmploymentTypeAsync(EmploymentType EmploymentType);

    public Task<string> UpdateAsync(EmploymentType EmploymentType);

    public Task<string> DeleteAsync(EmploymentType EmploymentType);
  }
}
