using Erp.Data.Entities.HumanResources.OrganizationalStructure;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.HumanResources.OrganizationalStructure;
using Erp.Service.Abstracts.HumanResources.OrganizationalStructure;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations.HumanResources.OrganizationalStructure
{
  public class EmploymentLevelService : IEmploymentLevelService
  {
    private readonly IEmploymentLevelRepository _EmploymentLevelRepository;


    public EmploymentLevelService(IEmploymentLevelRepository EmploymentLevelRepository)
    {
      _EmploymentLevelRepository = EmploymentLevelRepository;
    }
    public async Task<string> AddEmploymentLevelAsync(EmploymentLevel EmploymentLevel)
    {

      var newEmploymentLevel = await _EmploymentLevelRepository.AddAsync(EmploymentLevel);
      if (newEmploymentLevel != null)
      {
        return MessageCenter.CrudMessage.Success;
      }
      else
      {
        return "Somthing bad happend :";
      }
    }

    public async Task<string> DeleteAsync(EmploymentLevel EmploymentLevel)
    {
      try
      {
        await _EmploymentLevelRepository.DeleteAsync(EmploymentLevel);
        return MessageCenter.CrudMessage.Success;
      }
      catch (Exception ex)
      {
        return "There is a problem in deleteing the EmploymentLevel : " + ex.Message;
      }

    }

    public async Task<EmploymentLevel> GetEmploymentLevelByIdAsync(int id)
    {
      var EmploymentLevel = await _EmploymentLevelRepository.GetTableNoTracking().Where(x => x.ID == id).SingleOrDefaultAsync();

      return EmploymentLevel;
    }

    public async Task<List<EmploymentLevel>> GetEmploymentLevelsListAsync()
    {
      var EmploymentLevels = await _EmploymentLevelRepository.GetTableNoTracking().ToListAsync();

      return EmploymentLevels;
    }

    public async Task<string> UpdateAsync(EmploymentLevel EmploymentLevel)
    {
      var transact = _EmploymentLevelRepository.BeginTransaction();
      try
      {
        await _EmploymentLevelRepository.UpdateAsync(EmploymentLevel);

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
