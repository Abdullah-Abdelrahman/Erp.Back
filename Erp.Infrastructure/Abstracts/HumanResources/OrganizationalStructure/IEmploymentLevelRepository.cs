using Erp.Data.Entities.HumanResources.OrganizationalStructure;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.HumanResources.OrganizationalStructure
{
  public interface IEmploymentLevelRepository : IGenericRepository<EmploymentLevel>
  {
    public Task<string> AddEmploymentLevelAsync(EmploymentLevel EmploymentLevel);

    public Task<EmploymentLevel?> GetEmploymentLevelByIdAsync(int id);

    public Task<List<EmploymentLevel>> GetEmploymentLevelsListAsync();

    public Task<string> UpdateEmploymentLevelAsync(EmploymentLevel request);
  }
}
