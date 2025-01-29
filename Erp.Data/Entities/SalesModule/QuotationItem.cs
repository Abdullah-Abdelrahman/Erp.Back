using Erp.Data.Entities.InventoryModule;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.SalesModule
{
  public class QuotationItem
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public int QuotationId { get; set; }

    [ForeignKey(nameof(QuotationId))]
    public Quotation Quotation { get; set; } = null!;
    [Required]
    public int ProductId { get; set; }

    [ForeignKey("ProductId")]
    public Product Product { get; set; } = null!;

    [Required]
    public string Description { get; set; } = string.Empty;

    [Required]
    public decimal UnitPrice { get; set; }

    [Required]
    public int Quantity { get; set; }

    public decimal Discount { get; set; }
    public decimal Tax { get; set; }
    public decimal Total => (UnitPrice * Quantity) - Discount + Tax;
  }

}
