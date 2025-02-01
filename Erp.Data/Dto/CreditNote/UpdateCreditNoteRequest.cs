namespace Erp.Data.Dto.CreditNote
{
  public class UpdateCreditNoteRequest
  {
    public int CreditNoteId { get; set; }
    public int CustomerID { get; set; }


    public DateTime CreditNoteDate { get; set; } = DateTime.Now;

    public DateTime ReleaseDate { get; set; } = DateTime.Now;

    public decimal Discount { get; set; }

    public decimal Total { get; set; }


    public List<CreditNoteItemUpdateDT0> CreditNoteItems { get; set; }
  }

  public class CreditNoteItemUpdateDT0
  {
    public int CreditNoteItemId { get; set; }
    public int CreditNoteId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal discount { get; set; }
    public decimal Tax { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public string? Description { get; set; } = string.Empty;


  }
}
