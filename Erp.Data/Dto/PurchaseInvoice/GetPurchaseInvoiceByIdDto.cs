namespace Erp.Data.Dto.PurchaseInvoice
{
  public class GetPurchaseInvoiceByIdDto
  {
    public int PurchaseInvoiceId { get; set; }
    public DateTime InvoiceDate { get; set; } = DateTime.UtcNow;
    public decimal TotalAmount { get; set; }
    public string? Notes { get; set; }

    public int SupplierId { get; set; }

    public int JournalEntryID { get; set; }

    public List<PurchaseInvoiceItemDto> PurchaseInvoiceItemsDto { get; set; } = new List<PurchaseInvoiceItemDto>();
  }

  public class PurchaseInvoiceItemDto
  {

    public int PurchaseInvoiceItemId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal discount { get; set; }
    public decimal Tax { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
  }

}
