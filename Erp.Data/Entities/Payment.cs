using Erp.Data.Entities.AccountsModule;
using Erp.Data.Entities.Finance;
using Erp.Data.Entities.MainModule;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities
{
  public class Payment : IMustHaveTenant
  {
    public int Id { get; set; }

    public string PaymentMethod { get; set; } = "Cash";

    public decimal Amount { get; set; } = 0.0M;

    public DateTime? CreatedDate { get; set; }

    public string AddedById { get; set; }
    [ForeignKey("AddedById")]
    public UserBase AddedBy { get; set; } = null!;

    public int treasuryId { get; set; }
    [ForeignKey("treasuryId")]
    public Treasury treasury { get; set; }

    public int JournalEntryID { get; set; }
    [ForeignKey("JournalEntryID")]
    public JournalEntry JournalEntry { get; set; }
    [MaxLength(3)]
    public string Currency { get; set; } = null!;

    public string TenantId { get; set; } = null!;
  }


}
