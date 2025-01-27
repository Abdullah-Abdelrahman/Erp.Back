namespace Erp.Data.Entities.AccountsModule
{
  public class PrimaryAccount : Account
  {

    // Foreign key relationship
    public ICollection<Account> ChildAccounts { get; set; } = new List<Account>();
  }



}
