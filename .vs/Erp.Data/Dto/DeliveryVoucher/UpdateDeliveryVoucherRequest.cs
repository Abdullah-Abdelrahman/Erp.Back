namespace Erp.Data.Dto.DeliveryVoucher
{
  public class UpdateDeliveryVoucherRequest
  {
    public int DeliveryVoucherId { get; set; }
    public DateTime DeliveryDate { get; set; }
    public string? Notes { get; set; }

    // Foreign Keys
    public int WarehouseId { get; set; }

    public List<DeliveryVoucherItemUpdateDT0> DeliveryVoucherItems { get; set; }
  }

  public class DeliveryVoucherItemUpdateDT0
  {
    public int DeliveryVoucherItemId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => Quantity * UnitPrice;
    public int ProductId { get; set; }

  }
}
