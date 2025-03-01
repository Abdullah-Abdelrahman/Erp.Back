using System.ComponentModel.DataAnnotations;

namespace Erp.Data.Dto.Treasury
{
  public class AddTreasuryRequest
  {
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }


    public string? Description { get; set; }

    [Required]
    public bool IsActive { get; set; } = true;



    public WhoHaveType DepositPermission { get; set; } = WhoHaveType.None;
    public WhoHaveType WithdrawPermission { get; set; } = WhoHaveType.None;
    public ICollection<int> employeesWhoHaveDepositPermessionsIds { get; set; } = new List<int>();
    public ICollection<string> RolesWhoHaveWithdrawPermessionsIds { get; set; } = new List<string>();
    public ICollection<int> employeesWhoHaveWithdrawPermessionsIds { get; set; } = new List<int>();

    public ICollection<string> RolesWhoHaveDepositPermessionsIds { get; set; } = new List<string>();
  }



}
