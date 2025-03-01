namespace Erp.Data.Dto.PurchaseReturn
{
  public class UpdatePurchaseReturnRequest
  {
    public int PurchaseReturnId { get; set; }
    public DateTime InvoiceDate { get; set; } = DateTime.UtcNow;
    public decimal TotalAmount { get; set; }
    public string? Notes { get; set; }

    public int SupplierId { get; set; }

    public List<PurchaseReturnItemUpdateDT0> PurchaseReturnItems { get; set; }
  }

  public class PurchaseReturnItemUpdateDT0
  {
    public int? PurchaseReturnItemId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal discount { get; set; }
    public decimal Tax { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }

  }
}
