namespace Erp.Data.Dto.CreditNote
{
  public class AddCreditNoteRequest
  {
    public int CustomerID { get; set; }


    public DateTime CreditNoteDate { get; set; } = DateTime.Now;

    public DateTime ReleaseDate { get; set; } = DateTime.Now;

    public decimal Discount { get; set; }

    public decimal Total { get; set; }


    public string? Reason { get; set; } = string.Empty;

    public List<CreditNoteItemDT0> CreditNoteItemDT0s { get; set; } = new List<CreditNoteItemDT0>();
  }


  public class CreditNoteItemDT0
  {

    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; }
    public decimal discount { get; set; }
    public decimal Tax { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }

  }
}
