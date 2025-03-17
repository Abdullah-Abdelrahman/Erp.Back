namespace Erp.Data.Dto.PurchaseReturn
{
  public class AddPurchaseReturnRequest
  {
    public DateTime InvoiceDate { get; set; } = DateTime.UtcNow;
    public decimal TotalAmount { get; set; }
    public string? Notes { get; set; }

    public int SupplierId { get; set; }

    public bool AlreadyPaid { get; set; }

    public decimal AmountPaid { get; set; }
    public List<PurchaseReturnItemDT0> PurchaseReturnItemDT0s { get; set; } = new List<PurchaseReturnItemDT0>();
  }


  public class PurchaseReturnItemDT0
  {

    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal discount { get; set; }
    public decimal Tax { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }

  }
}
