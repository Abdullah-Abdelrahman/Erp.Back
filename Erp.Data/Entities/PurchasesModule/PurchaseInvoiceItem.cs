using Erp.Data.Entities.InventoryModule;

namespace Erp.Data.Entities.PurchasesModule
{
  public class PurchaseInvoiceItem
  {
    public int PurchaseInvoiceItemId { get; set; }
    public int PurchaseInvoiceId { get; set; }
    public PurchaseInvoice PurchaseInvoice { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int Quantity { get; set; }


    public decimal discount { get; set; }
    public decimal Tax { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => Quantity * UnitPrice;
  }
}
