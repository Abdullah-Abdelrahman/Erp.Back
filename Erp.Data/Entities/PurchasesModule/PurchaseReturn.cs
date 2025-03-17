using Erp.Data.Entities.AccountsModule;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Erp.Data.Entities.PurchasesModule
{


  public class PurchaseReturn : IMustHaveTenant
  {
    public int PurchaseReturnId { get; set; }
    public DateTime ReturnDate { get; set; } = DateTime.UtcNow;
    public decimal TotalAmount { get; set; }
    public string? Notes { get; set; }

    // Navigation Properties
    public int supplierId { get; set; }
    [JsonIgnore]
    [ForeignKey("supplierId")]
    public Supplier supplier { get; set; }
    public int JournalEntryID { get; set; }
    [ForeignKey("JournalEntryID")]
    public JournalEntry JournalEntry { get; set; }


    public int paymentStatusId { get; set; }
    [ForeignKey("paymentStatusId")]
    public PaymentStatus paymentStatus { get; set; }
    public ICollection<PurchaseReturnItem> Items { get; set; } = new List<PurchaseReturnItem>();
    public ICollection<SupplierPayment> payments { get; set; } = new List<SupplierPayment>();
    public string TenantId { get; set; } = null!;

  }

}
