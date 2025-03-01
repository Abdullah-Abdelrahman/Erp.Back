using Erp.Data.Entities.HumanResources.OrganizationalStructure;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.HumanResources.OrganizationalStructure
{
  public interface IJobTypeRepository : IGenericRepository<JobType>
  {
    public Task<string> AddJobTypeAsync(JobType JobType);

    public Task<JobType?> GetJobTypeByIdAsync(int id);

    public Task<List<JobType>> GetJobTypesListAsync();

    public Task<string> UpdateJobTypeAsync(JobType request);
  }
}
