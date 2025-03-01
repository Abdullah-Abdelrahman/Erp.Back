namespace Erp.Data.Entities.PurchasesModule
{
  public class Supplier : IMustHaveTenant
  {
    public int SupplierId { get; set; }
    public string SupplierName { get; set; } = null!;
    public string? ContactInfo { get; set; }
    public string? Address { get; set; }

    // Navigation Properties
    public ICollection<PurchaseInvoice> PurchaseInvoices { get; set; } = new List<PurchaseInvoice>();
    public string TenantId { get; set; } = null!;
  }

}
