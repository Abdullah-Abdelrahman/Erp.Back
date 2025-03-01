using Erp.Data.Dto.RecurringInvoice;
using Erp.Data.Entities.InventoryModule;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.SalesModule
{
  public class RecurringInvoiceItem : IMustHaveTenant
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
    public decimal Total { get; set; } = 0;

    public string TenantId { get; set; } = null!;

    public RecurringInvoiceItem(RecurringInvoiceItemDT0 itemDT0, int RecurringInvoiceItemID)
    {
      RInvoiceID = RecurringInvoiceItemID;
      productID = itemDT0.ProductId;
      Description = itemDT0.Description;
      Quantity = itemDT0.Quantity;
      UnitPrice = itemDT0.UnitPrice;
      Discount = itemDT0.discount;
      Tax = itemDT0.Tax;

      Total = (itemDT0.UnitPrice * itemDT0.Quantity) - itemDT0.discount + itemDT0.Tax;

    }

    public RecurringInvoiceItem(RecurringInvoiceItemUpdateDT0 itemDT0)
    {
      if (itemDT0.RecurringInvoiceItemId != null)
      {
        ID = (int)itemDT0.RecurringInvoiceItemId;

      }
      RInvoiceID = itemDT0.RecurringInvoiceId;
      productID = itemDT0.ProductId;
      Description = itemDT0.Description;
      Quantity = itemDT0.Quantity;
      UnitPrice = itemDT0.UnitPrice;
      Discount = itemDT0.discount;
      Tax = itemDT0.Tax;
      Total = (itemDT0.UnitPrice * itemDT0.Quantity) - itemDT0.discount + itemDT0.Tax;

    }

    public RecurringInvoiceItem()
    {

    }
  }
}
