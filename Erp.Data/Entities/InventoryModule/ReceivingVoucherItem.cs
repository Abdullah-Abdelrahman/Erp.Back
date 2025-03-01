namespace Erp.Data.Entities.InventoryModule
{
  public class ReceivingVoucherItem : IMustHaveTenant
  {
    public int ReceivingVoucherItemId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => Quantity * UnitPrice;

    // Foreign Keys
    public int receivingVoucherId { get; set; }
    public ReceivingVoucher receivingVoucher { get; set; } = null!;

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public string TenantId { get; set; } = null!;

  }

}
