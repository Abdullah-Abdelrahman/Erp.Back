using Erp.Data.Entities.HumanResources.Staff;

namespace Erp.Data.Abstracts
{
  public interface IFinancePermissions
  {


    public WhoHaveType DepositPermission { get; set; }

    public WhoHaveType WithdrawPermission { get; set; }


    public ICollection<Employee> employeesWhoHaveDepositPermessions { get; set; }

    public ICollection<ApplicationRole> RolesWhoHaveWithdrawPermessions { get; set; }

    public ICollection<Employee> employeesWhoHaveWithdrawPermessions { get; set; }

    public ICollection<ApplicationRole> RolesWhoHaveDepositPermessions { get; set; }

    //public ICollection<Branch> BranchsWhoHavePermessions { get; set; }

  }

  public enum WhoHaveType
  {
    None,
    Every_One,
    Job_Role,
    Employee,
    Branch

  }
}
