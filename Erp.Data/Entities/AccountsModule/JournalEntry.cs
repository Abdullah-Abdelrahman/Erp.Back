using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.AccountsModule
{
  public class JournalEntry : IMustHaveTenant
  {
    [Key]
    public int JournalEntryID { get; set; }


    [Column(TypeName = "datetime")]
    public DateTime EntryDate { get; set; } = DateTime.UtcNow;

    [MaxLength(255)]
    public string Description { get; set; }


    public ICollection<JournalEntryDetail> details { get; set; } = new List<JournalEntryDetail>();

    public string TenantId { get; set; } = null!;

  }
}
