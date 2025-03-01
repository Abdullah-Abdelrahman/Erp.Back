using Erp.Data.Entities.HumanResources.OrganizationalStructure;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.HumanResources.OrganizationalStructure;
using Erp.Service.Abstracts.HumanResources.OrganizationalStructure;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations.HumanResources.OrganizationalStructure
{
  public class DepartmentService : IDepartmentService
  {
    private readonly IDepartmentRepository _DepartmentRepository;


    public DepartmentService(IDepartmentRepository DepartmentRepository)
    {
      _DepartmentRepository = DepartmentRepository;
    }
    public async Task<string> AddDepartmentAsync(Department Department)
    {

      var newDepartment = await _DepartmentRepository.AddAsync(Department);
      if (newDepartment != null)
      {
        return MessageCenter.CrudMessage.Success;
      }
      else
      {
        return "Somthing bad happend :";
      }
    }

    public async Task<string> DeleteAsync(Department Department)
    {
      try
      {
        await _DepartmentRepository.DeleteAsync(Department);
        return MessageCenter.CrudMessage.Success;
      }
      catch (Exception ex)
      {
        return "There is a problem in deleteing the Department : " + ex.Message;
      }

    }

    public async Task<Department> GetDepartmentByIdAsync(int id)
    {
      var Department = await _DepartmentRepository.GetTableNoTracking().Where(x => x.DepartmentID == id).SingleOrDefaultAsync();

      return Department;
    }

    public async Task<List<Department>> GetDepartmentsListAsync()
    {
      var Departments = await _DepartmentRepository.GetTableNoTracking().ToListAsync();

      return Departments;
    }

    public async Task<string> UpdateAsync(Department Department)
    {
      var transact = _DepartmentRepository.BeginTransaction();
      try
      {
        await _DepartmentRepository.UpdateAsync(Department);

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

