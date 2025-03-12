namespace Erp.Data.Dto.DebitNote
{
  public class GetDebitNoteByIdDto
  {
    public int DebitNoteId { get; set; }
    public DateTime InvoiceDate { get; set; } = DateTime.UtcNow;
    public decimal TotalAmount { get; set; }
    public string? Notes { get; set; }

    public int SupplierId { get; set; }

    public int JournalEntryID { get; set; }

    public List<DebitNoteItemDto> DebitNoteItemsDto { get; set; } = new List<DebitNoteItemDto>();
  }

  public class DebitNoteItemDto
  {

    public int DebitNoteItemId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal discount { get; set; }
    public decimal Tax { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
  }

}
