using Name.Data.Entities;

namespace Erp.Data.Entities
{
  public class ReceivingVoucherItem
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
  }

}
