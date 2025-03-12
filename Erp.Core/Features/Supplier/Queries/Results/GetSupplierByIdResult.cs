using Entitis = Erp.Data.Entities;

namespace Erp.Core.Features.Supplier.Queries.Results
{
  public class GetSupplierByIdResult
  {
    public int SupplierId { get; set; }
    public string SupplierName { get; set; } = null!;
    public string? ContactInfo { get; set; }
    public string? Address { get; set; }
    public int AccountId { get; set; } // الحساب الفرعي (اختياري)

    // Navigation Properties
    public ICollection<Entitis.PurchasesModule.PurchaseInvoice> PurchaseInvoices { get; set; } = new List<Entitis.PurchasesModule.PurchaseInvoice>();



  }
}
