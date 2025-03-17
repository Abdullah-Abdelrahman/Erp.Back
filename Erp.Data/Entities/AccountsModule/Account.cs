using Erp.Data.Entities.Finance;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.AccountsModule
{
  public class Account : IMustHaveTenant
  {
    public int AccountID { get; set; }

    //public int CompanyID { get; set; }

    public string AccountName { get; set; } = string.Empty;
    //داءن او مدين
    public AccountType Type { get; set; }

    public decimal Balance { get; set; }

    public int? ParentAccountID { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    // Navigation properties
    //[ForeignKey("CompanyID")]
    // public Company Company { get; set; } = null!;

    [ForeignKey("ParentAccountID")]
    public PrimaryAccount? ParentAccount { get; set; }

    public ICollection<Expense> expenses { get; set; } = new List<Expense>();

    public ICollection<Receipt> receipts { get; set; } = new List<Receipt>();

    public string TenantId { get; set; } = null!;
  }
  public enum AccountType
  {
    //مدين
    debtor,
    //داءن
    creditor
  }
  public enum PrimaryOrSecondary
  {

    Primary,
    Secondary
  }
}
