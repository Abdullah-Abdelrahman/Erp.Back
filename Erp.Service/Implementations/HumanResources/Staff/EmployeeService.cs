using Erp.Data.Entities.HumanResources.Staff;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.HumanResources.Staff;
using Erp.Service.Abstracts.HumanResources.Staff;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations.HumanResources.Staff
{
  public class EmployeeService : IEmployeeService
  {
    private readonly IEmployeeRepository _EmployeeRepository;


    public EmployeeService(IEmployeeRepository EmployeeRepository)
    {
      _EmployeeRepository = EmployeeRepository;
    }
    public async Task<string> AddEmployeeAsync(Employee Employee)
    {

      if (Employee.Notes == null)
      {
        Employee.Notes = string.Empty;
      }
      var newEmployee = await _EmployeeRepository.AddAsync(Employee);
      if (newEmployee != null)
      {
        return MessageCenter.CrudMessage.Success;
      }
      else
      {
        return "Somthing bad happend :";
      }
    }

    public async Task<string> DeleteAsync(Employee Employee)
    {
      try
      {
        await _EmployeeRepository.DeleteAsync(Employee);
        return MessageCenter.CrudMessage.Success;
      }
      catch (Exception ex)
      {
        return "There is a problem in deleteing the Employee : " + ex.Message;
      }

    }

    public async Task<Employee?> GetEmployeeByIdAsync(int id)
    {
      var Employee = await _EmployeeRepository.GetTableNoTracking().Where(x => x.EmployeeID == id).SingleOrDefaultAsync();

      return Employee;
    }

    public async Task<List<Employee>> GetEmployeesListAsync()
    {
      var Employees = await _EmployeeRepository.GetTableNoTracking().ToListAsync();

      return Employees;
    }

    public async Task<string> UpdateAsync(Employee Employee)
    {
      var transact = _EmployeeRepository.BeginTransaction();
      try
      {
        await _EmployeeRepository.UpdateAsync(Employee);

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
