using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.InventoryModule
{
  public class TransformVoucherItem
  {
    public int TransformVoucherItemId { get; set; }
    public int Quantity { get; set; }

    // Foreign Keys
    public int transformVoucherId { get; set; }
    [ForeignKey("transformVoucherId")]
    public TransformVoucher transformVoucher { get; set; } = null!;

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
  }
}
