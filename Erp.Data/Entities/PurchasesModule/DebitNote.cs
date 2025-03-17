using Erp.Data.Entities.AccountsModule;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Erp.Data.Entities.PurchasesModule
{
  public class DebitNote : IMustHaveTenant
  {
    public int DebitNoteId { get; set; }
    public DateTime NoteDate { get; set; } = DateTime.UtcNow;
    public decimal Amount { get; set; }
    public string? Notes { get; set; }

    // Navigation Properties
    public int SupplierId { get; set; }
    [JsonIgnore]
    public Supplier Supplier { get; set; }
    public int JournalEntryID { get; set; }
    [ForeignKey("JournalEntryID")]
    public JournalEntry JournalEntry { get; set; }


    public int paymentStatusId { get; set; }
    [ForeignKey("paymentStatusId")]
    public PaymentStatus paymentStatus { get; set; }
    public ICollection<DebitNoteItem> Items { get; set; } = new List<DebitNoteItem>();

    public string TenantId { get; set; } = null!;

  }
}
