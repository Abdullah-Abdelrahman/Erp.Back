using Erp.Data.Entities;

namespace Erp.Core.Features.Supplier.Queries.Results
{
  public class GetSupplierByIdResult
  {
    public int SupplierId { get; set; }
    public string SupplierName { get; set; } = null!;
    public string? ContactInfo { get; set; }
    public string? Address { get; set; }

    // Navigation Properties
    public ICollection<PurchaseInvoice> PurchaseInvoices { get; set; } = new List<PurchaseInvoice>();

    public ICollection<SupplierPayment> SupplierPayments { get; set; } = new List<SupplierPayment>();

  }
}
