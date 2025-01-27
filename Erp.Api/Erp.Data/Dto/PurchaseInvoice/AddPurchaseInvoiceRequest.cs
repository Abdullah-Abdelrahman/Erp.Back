namespace Erp.Data.Dto.PurchaseInvoice
{
  public class AddPurchaseInvoiceRequest
  {
    public DateTime InvoiceDate { get; set; } = DateTime.UtcNow;
    public decimal TotalAmount { get; set; }
    public string? Notes { get; set; }

    public int SupplierId { get; set; }

    public List<PurchaseInvoiceItemDT0> PurchaseInvoiceItemDT0s { get; set; } = new List<PurchaseInvoiceItemDT0>();
  }


  public class PurchaseInvoiceItemDT0
  {

    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal discount { get; set; }
    public decimal Tax { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }

  }
}
