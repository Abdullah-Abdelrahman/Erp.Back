using Erp.Data.Entities.Finance;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace Erp.Data.Entities.HumanResources.Staff
{
  public class ApplicationRole : IdentityRole, IMustHaveTenant
  {
    [JsonIgnore]
    public string TenantId { get; set; } = null!;

    [JsonIgnore]
    public ICollection<BankAccount> BankAccountDepositPermessions { get; set; } = new List<BankAccount>();
    [JsonIgnore]
    public ICollection<BankAccount> BankAccountWithdrawPermessions { get; set; } = new List<BankAccount>();
    [JsonIgnore]
    public ICollection<Treasury> TreasuryDepositPermessions { get; set; } = new List<Treasury>();

    [JsonIgnore]
    public ICollection<Treasury> TreasuryWithdrawPermessions { get; set; } = new List<Treasury>();




  }
}
