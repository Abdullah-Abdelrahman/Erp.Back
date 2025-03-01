using Erp.Data.Entities.Finance;
using Erp.Data.Entities.HumanResources.Staff;

namespace Erp.Data.Dto.BankAccount
{
  public class GetBankAccountByIdDto
  {

    public int BankAccountID { get; set; }


    public string AccountHolderName { get; set; }


    public string BankName { get; set; }


    public string AccountNumber { get; set; }



    public string Currency { get; set; }


    public AccountStatus Status { get; set; } = AccountStatus.ACTIVE;

    public WhoHaveType DepositPermission { get; set; } = WhoHaveType.None;
    public WhoHaveType WithdrawPermission { get; set; } = WhoHaveType.None;

    public ICollection<Employee> employeesWhoHaveDepositPermessions { get; set; } = new List<Employee>();
    public ICollection<ApplicationRole> RolesWhoHaveWithdrawPermessions { get; set; } = new List<ApplicationRole>();
    public ICollection<Employee> employeesWhoHaveWithdrawPermessions { get; set; } = new List<Employee>();

    public ICollection<ApplicationRole> RolesWhoHaveDepositPermessions { get; set; } = new List<ApplicationRole>();
  }



}
