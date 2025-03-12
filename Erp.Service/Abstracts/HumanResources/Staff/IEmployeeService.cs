using Erp.Data.Entities.HumanResources.Staff;

namespace Erp.Service.Abstracts.HumanResources.Staff
{
  public interface IEmployeeService
  {
    public Task<List<Employee>> GetEmployeesListAsync();

    public Task<Employee?> GetEmployeeByIdAsync(int id);

    public Task<string> AddEmployeeAsync(Employee Employee);

    public Task<string> UpdateAsync(Employee Employee);

    public Task<string> DeleteAsync(Employee Employee);
  }
}
