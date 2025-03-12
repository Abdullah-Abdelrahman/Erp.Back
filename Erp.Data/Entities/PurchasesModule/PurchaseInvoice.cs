using Erp.Data.Entities.AccountsModule;
using System.ComponentModel.DataAnnotations.Schema;

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
    public Supplier Supplier { get; set; }

    public int JournalEntryID { get; set; }
    [ForeignKey("JournalEntryID")]
    public JournalEntry JournalEntry { get; set; }
    public ICollection<PurchaseInvoiceItem> Items { get; set; } = new List<PurchaseInvoiceItem>();
    public string TenantId { get; set; } = null!;

  }
}
