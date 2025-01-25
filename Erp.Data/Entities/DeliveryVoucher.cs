using Name.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities
{
  public class DeliveryVoucher
  {
    public int DeliveryVoucherId { get; set; }
    public DateTime DeliveryDate { get; set; } = DateTime.UtcNow;
    public string? Notes { get; set; }

    // Foreign Keys
    public int WarehouseId { get; set; }
    [ForeignKey("WarehouseId")]
    public Warehouse Warehouse { get; set; }


    // Navigation Property
    public ICollection<DeliveryVoucherItem> deliveryVoucherItems { get; set; } = new List<DeliveryVoucherItem>();
  }

}
