using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.AccountsModule
{
  public class Account
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
    public Account? ParentAccount { get; set; }


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
