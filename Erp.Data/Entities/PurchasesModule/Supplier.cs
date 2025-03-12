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
    public string TenantId { get; set; } = null!;
  }

}
