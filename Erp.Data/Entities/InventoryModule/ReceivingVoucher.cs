using Erp.Data.Entities.AccountsModule;
using Erp.Data.Entities.PurchasesModule;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.InventoryModule
{
  // Anouther Name is InBound Requisition 
  public class ReceivingVoucher : IMustHaveTenant
  {
    public int ReceivingVoucherId { get; set; }
    public DateTime ReceivingDate { get; set; } = DateTime.UtcNow;
    public string? Notes { get; set; }

    // Foreign Keys
    public int WarehouseId { get; set; }
    [ForeignKey("WarehouseId")]
    public Warehouse Warehouse { get; set; }

    // Foreign Key - Account
    public int AccountId { get; set; }
    [ForeignKey("AccountId")]
    public Account Account { get; set; } = null!;

    public int VoucherStatusId { get; set; }
    [ForeignKey("VoucherStatusId")]
    public VoucherStatus VoucherStatus { get; set; }
    // Navigation Property

    public int? SupplierId { get; set; }
    [ForeignKey("SupplierId")]
    public Supplier? Supplier { get; set; }

    public int JournalEntryID { get; set; }
    [ForeignKey("JournalEntryID")]
    public JournalEntry JournalEntry { get; set; }

    public int? purchaseInvoiceId { get; set; }
    [ForeignKey("purchaseInvoiceId")]
    public PurchaseInvoice? purchaseInvoice { get; set; }

    public ICollection<ReceivingVoucherItem> receivingVoucherItems { get; set; } = new List<ReceivingVoucherItem>();

    public string TenantId { get; set; } = null!;

  }

}
