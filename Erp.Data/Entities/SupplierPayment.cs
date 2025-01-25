namespace Erp.Data.Entities
{
  public class SupplierPayment
  {
    public int SupplierPaymentId { get; set; }
    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
    public decimal Amount { get; set; }
    public string? Notes { get; set; }

    // Navigation Properties
    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; }
  }
}
