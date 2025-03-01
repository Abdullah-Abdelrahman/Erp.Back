namespace Erp.Data.Entities.InventoryModule
{
  public class DeliveryVoucherItem : IMustHaveTenant
  {
    public int DeliveryVoucherItemId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => Quantity * UnitPrice;

    // Foreign Keys
    public int deliveryVoucherId { get; set; }
    public DeliveryVoucher deliveryVoucher { get; set; } = null!;

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public string TenantId { get; set; } = null!;

  }

}
