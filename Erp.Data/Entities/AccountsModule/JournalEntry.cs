using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.AccountsModule
{
  public class JournalEntry
  {
    [Key]
    public int JournalEntryID { get; set; }

    //public int CompanyID { get; set; }
    //[ForeignKey("CompanyID")]
    //public Company Company { get; set; }


    [Column(TypeName = "datetime")]
    public DateTime EntryDate { get; set; } = DateTime.UtcNow;

    [MaxLength(255)]
    public string Description { get; set; }

    public List<JournalEntryDetail>? details { get; set; } = new();

  }
}
