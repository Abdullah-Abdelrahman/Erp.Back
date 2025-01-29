using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.SalesModule
{
  public class InvoiceItem
  {
    [Key]
    public int InvoiceItemID { get; set; }

    public int InvoiceID { get; set; }

    [ForeignKey("InvoiceID")]
    public Invoice Invoice { get; set; }

    [MaxLength(255)]
    public string? Description { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    [Required]
    public decimal UnitPrice { get; set; }

    public decimal Discount { get; set; } = 0;
    public decimal Tax { get; set; } = 0;
    public decimal Total => (UnitPrice * Quantity) - Discount + Tax;
  }
}
