using Erp.Data.Entities.HumanResources.OrganizationalStructure;

namespace Erp.Service.Abstracts.HumanResources.OrganizationalStructure
{
  public interface IEmploymentLevelService
  {
    public Task<List<EmploymentLevel>> GetEmploymentLevelsListAsync();

    public Task<EmploymentLevel> GetEmploymentLevelByIdAsync(int id);

    public Task<string> AddEmploymentLevelAsync(EmploymentLevel EmploymentLevel);

    public Task<string> UpdateAsync(EmploymentLevel EmploymentLevel);

    public Task<string> DeleteAsync(EmploymentLevel EmploymentLevel);
  }
}
