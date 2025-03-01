namespace Erp.Data.Dto.JournalEntry
{
  public class UpdateJournalEntryRequest
  {
    public int JournalEntryID { get; set; }
    public DateTime EntryDate { get; set; } = DateTime.UtcNow;

    public string Description { get; set; }



    public List<JournalEntryItemUpdateDT0> JournalEntryItems { get; set; }
  }

  public class JournalEntryItemUpdateDT0
  {
    public int? JournalEntryDetailID { get; set; }
    public int JournalEntryID { get; set; }
    public string? Description { get; set; }
    public int AccountID { get; set; }
    public decimal Debit { get; set; } = 0.00M;
    public decimal Credit { get; set; } = 0.00M;
    public int? CostCenterId { get; set; }

  }
}
