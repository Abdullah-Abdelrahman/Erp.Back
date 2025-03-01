using Erp.Data.Entities.HumanResources.OrganizationalStructure;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.HumanResources.OrganizationalStructure
{
  public interface IEmploymentTypeRepository : IGenericRepository<EmploymentType>
  {
    public Task<string> AddEmploymentTypeAsync(EmploymentType EmploymentType);

    public Task<EmploymentType?> GetEmploymentTypeByIdAsync(int id);

    public Task<List<EmploymentType>> GetEmploymentTypesListAsync();

    public Task<string> UpdateEmploymentTypeAsync(EmploymentType request);
  }
}
