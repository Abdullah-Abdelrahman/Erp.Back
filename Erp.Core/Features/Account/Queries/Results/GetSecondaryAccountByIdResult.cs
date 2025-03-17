using Erp.Data.Entities.AccountsModule;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Features.Account.Queries.Results
{
  public class GetSecondaryAccountByIdResult
  {
    public int AccountID { get; set; }

    public string AccountName { get; set; } = string.Empty;
    //داءن او مدين
    public AccountType Type { get; set; }
    //Primary,Secondary

    public int? ParentAccountID { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime AccCreatedDate { get; set; }



    // --- JournalEntry  ---- 

    public ICollection<Entitis.AccountsModule.JournalEntry>? journalEntrys { get; set; } = new List<Entitis.AccountsModule.JournalEntry>();
  }
}
