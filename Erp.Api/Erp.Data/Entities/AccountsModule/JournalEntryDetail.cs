using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.AccountsModule
{
  public class JournalEntryDetail
  {
    [Key]
    public int JournalEntryDetailID { get; set; }

    public int JournalEntryID { get; set; }
    [ForeignKey("JournalEntryID")]
    public JournalEntry JournalEntry { get; set; }

    public string? Description { get; set; }

    [ForeignKey("Account")]
    public int AccountID { get; set; }
    public Account Account { get; set; }

    [Column(TypeName = "decimal(15, 2)")]
    public decimal Debit { get; set; } = 0.00M;

    [Column(TypeName = "decimal(15, 2)")]
    public decimal Credit { get; set; } = 0.00M;


    public int? CostCenterId { get; set; }
    [ForeignKey("CostCenterId")]
    public SecondaryCostCenter? CostCenter { get; set; }
  }
}
