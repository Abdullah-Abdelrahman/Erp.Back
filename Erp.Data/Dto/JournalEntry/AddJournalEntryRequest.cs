using System.ComponentModel.DataAnnotations;

namespace Erp.Data.Dto.JournalEntry
{
  public class AddJournalEntryRequest
  {

    public DateTime EntryDate { get; set; } = DateTime.UtcNow;


    public string Description { get; set; }


    public List<JournalEntryItemDT0> JournalEntryItemDT0s { get; set; } = new List<JournalEntryItemDT0>();
  }


  public class JournalEntryItemDT0
  {

    public string? Description { get; set; }
    [Required]
    public int AccountID { get; set; }
    public decimal Debit { get; set; } = 0.00M;
    public decimal Credit { get; set; } = 0.00M;
    public int? CostCenterId { get; set; }


  }
}
