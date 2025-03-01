using Erp.Data.Entities.HumanResources.Staff;
using System.ComponentModel.DataAnnotations;

namespace Erp.Data.Entities.Finance
{
  public class Treasury : IMustHaveTenant, IFinancePermissions
  {

    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public string Description { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public string Type { get; } = "Treasury";


    public string TenantId { get; set; } = null!;

    public WhoHaveType DepositPermission { get; set; } = WhoHaveType.None;
    public WhoHaveType WithdrawPermission { get; set; } = WhoHaveType.None;
    public ICollection<Employee> employeesWhoHaveDepositPermessions { get; set; } = new List<Employee>();
    public ICollection<ApplicationRole> RolesWhoHaveWithdrawPermessions { get; set; } = new List<ApplicationRole>();
    public ICollection<Employee> employeesWhoHaveWithdrawPermessions { get; set; } = new List<Employee>();

    public ICollection<ApplicationRole> RolesWhoHaveDepositPermessions { get; set; } = new List<ApplicationRole>();
  }
}
