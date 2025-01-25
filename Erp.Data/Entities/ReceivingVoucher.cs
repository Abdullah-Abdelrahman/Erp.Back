using Name.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities
{
  public class ReceivingVoucher
  {
    public int ReceivingVoucherId { get; set; }
    public DateTime ReceivingDate { get; set; } = DateTime.UtcNow;
    public string? Notes { get; set; }

    // Foreign Keys
    public int WarehouseId { get; set; }
    [ForeignKey("WarehouseId")]
    public Warehouse Warehouse { get; set; }

    // Foreign Key - Supplier
    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; } = null!;


    // Navigation Property
    public ICollection<ReceivingVoucherItem> receivingVoucherItems { get; set; } = new List<ReceivingVoucherItem>();
  }

}
