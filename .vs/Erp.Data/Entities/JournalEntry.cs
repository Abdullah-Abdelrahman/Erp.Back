using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities
{
  public class JournalEntry
  {
    [Key]
    public int JournalEntryID { get; set; }

    [ForeignKey("Company")]
    public int CompanyID { get; set; }
    public Company Company { get; set; }

    [ForeignKey("Transaction")]
    public int? TransactionID { get; set; }  // Nullable to allow optional link to a transaction
    public Transaction Transaction { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EntryDate { get; set; } = DateTime.UtcNow;

    [MaxLength(255)]
    public string Description { get; set; }

    public EntryStatus entryStatus { get; set; } = EntryStatus.OPEN;  // Enum for EntryStatus

    // Enum to represent EntryStatus
    public enum EntryStatus
    {
      OPEN,
      POSTED,
      CANCELLED
    }
  }
}
