using Erp.Data.Entities.HumanResources.OrganizationalStructure;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.HumanResources.OrganizationalStructure;
using Erp.Service.Abstracts.HumanResources.OrganizationalStructure;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations.HumanResources.OrganizationalStructure
{
  public class EmploymentTypeService : IEmploymentTypeService
  {
    private readonly IEmploymentTypeRepository _EmploymentTypeRepository;


    public EmploymentTypeService(IEmploymentTypeRepository EmploymentTypeRepository)
    {
      _EmploymentTypeRepository = EmploymentTypeRepository;
    }
    public async Task<string> AddEmploymentTypeAsync(EmploymentType EmploymentType)
    {

      var newEmploymentType = await _EmploymentTypeRepository.AddAsync(EmploymentType);
      if (newEmploymentType != null)
      {
        return MessageCenter.CrudMessage.Success;
      }
      else
      {
        return "Somthing bad happend :";
      }
    }

    public async Task<string> DeleteAsync(EmploymentType EmploymentType)
    {
      try
      {
        await _EmploymentTypeRepository.DeleteAsync(EmploymentType);
        return MessageCenter.CrudMessage.Success;
      }
      catch (Exception ex)
      {
        return "There is a problem in deleteing the EmploymentType : " + ex.Message;
      }

    }

    public async Task<EmploymentType> GetEmploymentTypeByIdAsync(int id)
    {
      var EmploymentType = await _EmploymentTypeRepository.GetTableNoTracking().Where(x => x.ID == id).SingleOrDefaultAsync();

      return EmploymentType;
    }

    public async Task<List<EmploymentType>> GetEmploymentTypesListAsync()
    {
      var EmploymentTypes = await _EmploymentTypeRepository.GetTableNoTracking().ToListAsync();

      return EmploymentTypes;
    }

    public async Task<string> UpdateAsync(EmploymentType EmploymentType)
    {
      var transact = _EmploymentTypeRepository.BeginTransaction();
      try
      {
        await _EmploymentTypeRepository.UpdateAsync(EmploymentType);

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
