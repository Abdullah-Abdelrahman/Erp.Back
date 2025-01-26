namespace Erp.Data.Dto.DebitNote
{
  public class AddDebitNoteRequest
  {
    public DateTime InvoiceDate { get; set; } = DateTime.UtcNow;
    public decimal TotalAmount { get; set; }
    public string? Notes { get; set; }

    public int SupplierId { get; set; }

    public List<DebitNoteItemDT0> DebitNoteItemDT0s { get; set; } = new List<DebitNoteItemDT0>();
  }


  public class DebitNoteItemDT0
  {

    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal discount { get; set; }
    public decimal Tax { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }

  }
}
