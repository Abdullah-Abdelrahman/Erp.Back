using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities
{
  public class JournalEntryDetail
  {
    [Key]
    public int JournalEntryDetailID { get; set; }

    [ForeignKey("JournalEntry")]
    public int JournalEntryID { get; set; }
    public JournalEntry JournalEntry { get; set; }

    [ForeignKey("Account")]
    public int AccountID { get; set; }
    public Account Account { get; set; }

    [Column(TypeName = "decimal(15, 2)")]
    public decimal Debit { get; set; } = 0.00M;

    [Column(TypeName = "decimal(15, 2)")]
    public decimal Credit { get; set; } = 0.00M;
  }
}
