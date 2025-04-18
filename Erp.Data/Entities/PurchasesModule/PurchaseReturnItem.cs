using Erp.Data.Entities.InventoryModule;

namespace Erp.Data.Entities.PurchasesModule
{
  public class PurchaseReturnItem : IMustHaveTenant
  {
    public int PurchaseReturnItemId { get; set; }
    public int PurchaseReturnId { get; set; }
    public PurchaseReturn PurchaseReturn { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }

    public decimal discount { get; set; }
    public decimal Tax { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public string TenantId { get; set; } = null!;


  }
}
