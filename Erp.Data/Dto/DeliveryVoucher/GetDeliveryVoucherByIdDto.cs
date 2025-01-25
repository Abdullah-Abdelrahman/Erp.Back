using Erp.Data.Entities;

namespace Erp.Data.Dto.DeliveryVoucher
{
  public class GetDeliveryVoucherByIdDto
  {
    public int DeliveryVoucherId { get; set; }
    public DateTime DeliveryDate { get; set; } = DateTime.UtcNow;
    public string? Notes { get; set; }

    public Warehouse Warehouse { get; set; }

    public List<DeliveryVoucherItemDto> deliveryVoucherItemDto { get; set; } = new List<DeliveryVoucherItemDto>();
  }

  public class DeliveryVoucherItemDto
  {

    public int DeliveryVoucherItemId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public Product Product { get; set; } = null!;
  }
}
