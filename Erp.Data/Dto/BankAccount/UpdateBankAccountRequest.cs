using Erp.Data.Entities.Finance;
using System.ComponentModel.DataAnnotations;

namespace Erp.Data.Dto.BankAccount
{
  public class UpdateBankAccountRequest
  {
    [Required]
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

    public WhoHaveType DepositPermission { get; set; } = WhoHaveType.None;
    public WhoHaveType WithdrawPermission { get; set; } = WhoHaveType.None;
    public ICollection<int> employeesWhoHaveDepositPermessionsIds { get; set; } = new List<int>();
    public ICollection<string> RolesWhoHaveWithdrawPermessionsIds { get; set; } = new List<string>();
    public ICollection<int> employeesWhoHaveWithdrawPermessionsIds { get; set; } = new List<int>();

    public ICollection<string> RolesWhoHaveDepositPermessionsIds { get; set; } = new List<string>();
  }


}
