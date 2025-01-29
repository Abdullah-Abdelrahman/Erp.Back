namespace Erp.Data.Entities.PurchasesModule
{
  public class DebitNote
  {
    public int DebitNoteId { get; set; }
    public DateTime NoteDate { get; set; } = DateTime.UtcNow;
    public decimal Amount { get; set; }
    public string? Notes { get; set; }

    // Navigation Properties
    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; }

    public ICollection<DebitNoteItem> Items { get; set; } = new List<DebitNoteItem>();
  }
}
