using Erp.Data.Entities.HumanResources.OrganizationalStructure;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.HumanResources.OrganizationalStructure;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.HumanResources.OrganizationalStructure
{
  public class JobTypeRepository : GenericRepository<JobType>, IJobTypeRepository
  {
    private readonly DbSet<JobType> _JobTypes;
    public JobTypeRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _JobTypes = dbContext.Set<JobType>();

    }


    public async Task<string> AddJobTypeAsync(JobType JobType)
    {
      var result = await _JobTypes.AddAsync(JobType);

      if (result == null)
      {
        return "Cant Add";
      }
      else
      {
        return MessageCenter.CrudMessage.Success;
      }
    }

    public async Task<JobType?> GetJobTypeByIdAsync(int id)
    {
      return await _JobTypes.FindAsync(id);

    }

    public async Task<List<JobType>> GetJobTypesListAsync()
    {
      return await _JobTypes.ToListAsync();
    }

    public async Task<string> UpdateJobTypeAsync(JobType request)
    {
      var result = _JobTypes.Update(request);

      return MessageCenter.CrudMessage.Success;
    }
  }
}
