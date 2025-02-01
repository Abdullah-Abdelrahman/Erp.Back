using Erp.Data.Entities.InventoryModule;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.SalesModule
{
  public class RecurringInvoiceItem
  {
    [Key]
    public int ID { get; set; }

    public int RInvoiceID { get; set; }

    [ForeignKey("RInvoiceID")]
    public RecurringInvoice RInvoice { get; set; }

    public int productID { get; set; }

    [ForeignKey("productID")]
    public Product product { get; set; }

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
