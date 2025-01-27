using Erp.Data.Entities.AccountsModule;
using Entitis = Erp.Data.Entities;

namespace Erp.Core.Features.Account.Queries.Results
{
  public class GetPrimaryAccountByIdResult
  {
    public int AccountID { get; set; }

    public string AccountName { get; set; } = string.Empty;
    //داءن او مدين
    public AccountType Type { get; set; }
    //Primary,Secondary

    public int? ParentAccountID { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;


    public ICollection<Entitis.AccountsModule.Account>? ChildAccounts { get; set; } = new List<Entitis.AccountsModule.Account>();


  }
}
