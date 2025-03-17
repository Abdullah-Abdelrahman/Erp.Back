using Erp.Data.Entities.AccountsModule;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Erp.Data.Entities.PurchasesModule
{
  public class PurchaseInvoice : IMustHaveTenant
  {
    public int PurchaseInvoiceId { get; set; }
    public DateTime InvoiceDate { get; set; } = DateTime.UtcNow;
    public decimal TotalAmount { get; set; }
    public string? Notes { get; set; }

    public bool IsPaid { get; set; }
    //عدد الايام قبل استحقاق الدفع
    public int numberOfDaysToPay { get; set; }

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
    public ICollection<PurchaseInvoiceItem> Items { get; set; } = new List<PurchaseInvoiceItem>();

    [JsonIgnore]
    public ICollection<SupplierPayment> payments { get; set; } = new List<SupplierPayment>();
    public string TenantId { get; set; } = null!;

  }
}
