using Erp.Data.Entities.HumanResources.OrganizationalStructure;

namespace Erp.Service.Abstracts.HumanResources.OrganizationalStructure
{
  public interface IJobTypeService
  {
    public Task<List<JobType>> GetJobTypesListAsync();

    public Task<JobType> GetJobTypeByIdAsync(int id);

    public Task<string> AddJobTypeAsync(JobType JobType);

    public Task<string> UpdateAsync(JobType JobType);

    public Task<string> DeleteAsync(JobType JobType);
  }
}
