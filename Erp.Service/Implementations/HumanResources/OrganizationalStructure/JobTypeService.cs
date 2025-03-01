using Erp.Data.Entities.HumanResources.OrganizationalStructure;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.HumanResources.OrganizationalStructure;
using Erp.Service.Abstracts.HumanResources.OrganizationalStructure;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations.HumanResources.OrganizationalStructure
{
  public class JobTypeService : IJobTypeService
  {
    private readonly IJobTypeRepository _JobTypeRepository;


    public JobTypeService(IJobTypeRepository JobTypeRepository)
    {
      _JobTypeRepository = JobTypeRepository;
    }
    public async Task<string> AddJobTypeAsync(JobType JobType)
    {

      var newJobType = await _JobTypeRepository.AddAsync(JobType);
      if (newJobType != null)
      {
        return MessageCenter.CrudMessage.Success;
      }
      else
      {
        return "Somthing bad happend :";
      }
    }

    public async Task<string> DeleteAsync(JobType JobType)
    {
      try
      {
        await _JobTypeRepository.DeleteAsync(JobType);
        return MessageCenter.CrudMessage.Success;
      }
      catch (Exception ex)
      {
        return "There is a problem in deleteing the JobType : " + ex.Message;
      }

    }

    public async Task<JobType> GetJobTypeByIdAsync(int id)
    {
      var JobType = await _JobTypeRepository.GetTableNoTracking().Where(x => x.ID == id).SingleOrDefaultAsync();

      return JobType;
    }

    public async Task<List<JobType>> GetJobTypesListAsync()
    {
      var JobTypes = await _JobTypeRepository.GetTableNoTracking().ToListAsync();

      return JobTypes;
    }

    public async Task<string> UpdateAsync(JobType JobType)
    {
      var transact = _JobTypeRepository.BeginTransaction();
      try
      {
        await _JobTypeRepository.UpdateAsync(JobType);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch (Exception ex)
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied + ex.Message;
      }
    }
  }
}
