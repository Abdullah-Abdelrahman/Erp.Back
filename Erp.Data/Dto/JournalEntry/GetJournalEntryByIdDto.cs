namespace Erp.Data.Dto.JournalEntry
{
  public class GetJournalEntryByIdDto
  {

    public int JournalEntryID { get; set; }
    public DateTime EntryDate { get; set; } = DateTime.UtcNow;

    public string Description { get; set; }


    public List<JournalEntryItemDto> JournalEntryItemsDto { get; set; } = new List<JournalEntryItemDto>();
  }

  public class JournalEntryItemDto
  {

    public int JournalEntryDetailID { get; set; }
    public int JournalEntryID { get; set; }
    public string? Description { get; set; }
    public int AccountID { get; set; }
    public decimal Debit { get; set; } = 0.00M;
    public decimal Credit { get; set; } = 0.00M;
    public int? CostCenterId { get; set; }



  }

}
