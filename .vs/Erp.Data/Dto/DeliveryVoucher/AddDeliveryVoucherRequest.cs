namespace Erp.Data.Dto.DeliveryVoucher
{
  public class AddDeliveryVoucherRequest
  {
    public DateTime? DeliveryDate { get; set; }
    public string? Notes { get; set; }
    // Foreign Keys
    public int WarehouseId { get; set; }


    public List<DeliveryVoucherItemDT0> DeliveryVoucherItemDT0s { get; set; }
  }


  public class DeliveryVoucherItemDT0
  {

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => Quantity * UnitPrice;
    public int ProductId { get; set; }

  }
}
