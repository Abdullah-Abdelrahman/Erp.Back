namespace Erp.Data.Entities.AccountsModule
{
  public class SecondaryCostCenter : CostCenter
  {
    // Foreign key relationship
    public ICollection<JournalEntryDetail> journalEntryDetails { get; set; } = new List<JournalEntryDetail>();

  }
}
