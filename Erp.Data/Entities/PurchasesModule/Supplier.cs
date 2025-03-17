using Erp.Data.Entities.AccountsModule;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.PurchasesModule
{
  public class Supplier : IMustHaveTenant
  {
    public int SupplierId { get; set; }
    public string SupplierName { get; set; } = null!;
    public string? ContactInfo { get; set; }
    public string? Address { get; set; }

    public int AccountId { get; set; } // الحساب الفرعي (اختياري)

    [ForeignKey("AccountId")]
    public SecondaryAccount Account { get; set; }



    // Navigation Properties

    public ICollection<PurchaseInvoice> PurchaseInvoices { get; set; } = new List<PurchaseInvoice>();

    public ICollection<PurchaseReturn> PurchaseReturns { get; set; } = new List<PurchaseReturn>();
    public ICollection<DebitNote> DebitNotes { get; set; } = new List<DebitNote>();

    public ICollection<SupplierPayment> supplierPayments { get; set; } = new List<SupplierPayment>();

    public string TenantId { get; set; } = null!;
  }

}
