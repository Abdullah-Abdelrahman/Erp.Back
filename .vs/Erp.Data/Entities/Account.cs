namespace Erp.Data.Entities
{
  public class Account
  {
    public int AccountID { get; set; }

    public int CompanyID { get; set; }

    public string AccountName { get; set; } = string.Empty;

    public AccountType AccountType { get; set; }

    public int? ParentAccountID { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public Company Company { get; set; } = null!;

    public Account? ParentAccount { get; set; }

    // Foreign key relationship
    public ICollection<Account> ChildAccounts { get; set; } = new List<Account>();
  }

  public enum AccountType
  {
    ASSET,
    LIABILITY,
    EQUITY,
    INCOME,
    EXPENSE
  }

}
