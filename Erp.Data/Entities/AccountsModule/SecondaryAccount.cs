namespace Erp.Data.Entities.AccountsModule
{
  public class SecondaryAccount : Account
  {

    // Foreign key relationship
    public ICollection<JournalEntry> journalEntrys { get; set; } = new List<JournalEntry>();
  }
}
