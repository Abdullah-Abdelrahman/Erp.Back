namespace Erp.Data.Entities
{
  public class DebitNote
  {
    public int DebitNoteId { get; set; }
    public DateTime NoteDate { get; set; } = DateTime.UtcNow;
    public decimal Amount { get; set; }
    public string? Notes { get; set; }

    // Navigation Properties
    public int PurchaseInvoiceId { get; set; }
    public PurchaseInvoice PurchaseInvoice { get; set; }
  }
}
