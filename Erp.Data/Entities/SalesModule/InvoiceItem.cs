using Erp.Data.Dto.Invoice;
using Erp.Data.Entities.InventoryModule;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.SalesModule
{
  public class InvoiceItem : IMustHaveTenant
  {
    [Key]
    public int InvoiceItemID { get; set; }

    public int InvoiceID { get; set; }

    [ForeignKey("InvoiceID")]
    public Invoice Invoice { get; set; }

    public int productID { get; set; }

    [ForeignKey("productID")]
    public Product product { get; set; }

    [MaxLength(255)]
    public string? Description { get; set; } = string.Empty;

    [Required]
    public int Quantity { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    [Required]
    public decimal UnitPrice { get; set; }

    public decimal Discount { get; set; } = 0;
    public decimal Tax { get; set; } = 0;
    public decimal Total { get; set; }
    public string TenantId { get; set; } = null!;

    public InvoiceItem(InvoiceItemDT0 itemDT0, int invoiceID)
    {
      InvoiceID = invoiceID;
      productID = itemDT0.ProductId;
      Description = itemDT0.Description;
      Quantity = itemDT0.Quantity;
      UnitPrice = itemDT0.UnitPrice;
      Discount = itemDT0.discount;
      Tax = itemDT0.Tax;
      Total = (itemDT0.UnitPrice * itemDT0.Quantity) - itemDT0.discount + itemDT0.Tax;

    }

    public InvoiceItem(InvoiceItemUpdateDT0 itemDT0)
    {
      if (itemDT0.InvoiceItemId != null)
      {
        InvoiceItemID = (int)itemDT0.InvoiceItemId;

      }
      InvoiceID = itemDT0.InvoiceId;
      productID = itemDT0.ProductId;
      Description = itemDT0.Description;
      Quantity = itemDT0.Quantity;
      UnitPrice = itemDT0.UnitPrice;
      Discount = itemDT0.discount;
      Tax = itemDT0.Tax;
      Total = (itemDT0.UnitPrice * itemDT0.Quantity) - itemDT0.discount + itemDT0.Tax;
    }
    public InvoiceItem()
    {

    }
  }
}
