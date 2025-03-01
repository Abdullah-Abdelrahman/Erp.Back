using Erp.Data.Entities.HumanResources.Staff;
using System.ComponentModel.DataAnnotations;

namespace Erp.Data.Entities.Finance
{
  public class BankAccount : IMustHaveTenant, IFinancePermissions
  {
    [Key]
    public int BankAccountID { get; set; }


    [Required]
    [MaxLength(100)]
    public string AccountHolderName { get; set; }

    [Required]
    [MaxLength(100)]
    public string BankName { get; set; }

    [Required]
    [MaxLength(50)]
    public string AccountNumber { get; set; }


    [Required]
    [MaxLength(3)]
    public string Currency { get; set; }


    public AccountStatus Status { get; set; } = AccountStatus.ACTIVE;

    public string Type { get; } = "Bank Account";

    public string TenantId { get; set; } = null!;


    public WhoHaveType DepositPermission { get; set; } = WhoHaveType.None;
    public WhoHaveType WithdrawPermission { get; set; } = WhoHaveType.None;
    public ICollection<Employee> employeesWhoHaveDepositPermessions { get; set; } = new List<Employee>();
    public ICollection<ApplicationRole> RolesWhoHaveWithdrawPermessions { get; set; } = new List<ApplicationRole>();
    public ICollection<Employee> employeesWhoHaveWithdrawPermessions { get; set; } = new List<Employee>();

    public ICollection<ApplicationRole> RolesWhoHaveDepositPermessions { get; set; } = new List<ApplicationRole>();
  }

  public enum AccountStatus
  {
    ACTIVE,
    INACTIVE,
    CLOSED
  }
}
