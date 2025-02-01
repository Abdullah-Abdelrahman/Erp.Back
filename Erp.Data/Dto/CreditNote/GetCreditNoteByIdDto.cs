namespace Erp.Data.Dto.CreditNote
{
  public class GetCreditNoteByIdDto
  {
    public int CreditNoteId { get; set; }
    public int CustomerID { get; set; }


    public DateTime CreditNoteDate { get; set; } = DateTime.Now;

    public DateTime ReleaseDate { get; set; } = DateTime.Now;
    //عدد الايام لتصبح الفاتوره مستحقه الدفع
    public int PaymentTerms { get; set; } = 0;

    public decimal Tax { get; set; }
    public decimal Discount { get; set; }

    public decimal Total { get; set; }

    public string? Reason { get; set; } = string.Empty;


    public List<CreditNoteItemDto> CreditNoteItemsDto { get; set; } = new List<CreditNoteItemDto>();
  }

  public class CreditNoteItemDto
  {
    public int CreditNoteId { get; set; }
    public int CreditNoteItemId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; }
    public decimal discount { get; set; }
    public decimal Tax { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
  }

}
