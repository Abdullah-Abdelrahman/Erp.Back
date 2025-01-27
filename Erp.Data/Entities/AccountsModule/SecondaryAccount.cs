namespace Erp.Data.Entities.AccountsModule
{
  public class SecondaryAccount : Account
  {

    // Foreign key relationship
    public ICollection<JournalEntryDetail> journalEntryDetails { get; set; } = new List<JournalEntryDetail>();
  }
}
