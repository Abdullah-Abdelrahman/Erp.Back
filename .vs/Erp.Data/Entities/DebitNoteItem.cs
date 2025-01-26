using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities
{
  public class DebitNoteItem
  {

    public int DebitNoteItemId { get; set; }
    public int DebitNoteId { get; set; }
    [ForeignKey("DebitNoteId")]
    public DebitNote debitNote { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int Quantity { get; set; }


    public decimal discount { get; set; }
    public decimal Tax { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => Quantity * UnitPrice;
  }
}
