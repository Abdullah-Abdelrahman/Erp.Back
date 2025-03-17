using Erp.Data.Entities.AccountsModule;
using Erp.Data.Entities.CustomersModule;
using Erp.Data.Entities.PurchasesModule;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.InventoryModule
{
  public class DeliveryVoucher : IMustHaveTenant
  {
    public int DeliveryVoucherId { get; set; }
    public DateTime DeliveryDate { get; set; } = DateTime.UtcNow;
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



    public int? CustomerId { get; set; }
    [ForeignKey("CustomerId")]
    public Customer? Customer { get; set; }

    public int JournalEntryID { get; set; }
    [ForeignKey("JournalEntryID")]
    public JournalEntry JournalEntry { get; set; }

    public int? purchaseReturnId { get; set; }
    [ForeignKey("purchaseReturnId")]
    public PurchaseReturn? purchaseReturn { get; set; }


    public int? debitNoteId { get; set; }
    [ForeignKey("debitNoteId")]
    public DebitNote? debitNote { get; set; }
    // Navigation Property
    public ICollection<DeliveryVoucherItem> deliveryVoucherItems { get; set; } = new List<DeliveryVoucherItem>();
    public string TenantId { get; set; } = null!;


  }

}
