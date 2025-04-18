using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.InventoryModule
{
  public class TransformVoucher : IMustHaveTenant
  {
    public int TransformVoucherId { get; set; }
    public DateTime TransformDate { get; set; } = DateTime.UtcNow;
    public string? Notes { get; set; }

    // From to
    public int FromWarehouseId { get; set; }
    [ForeignKey("FromWarehouseId")]
    public Warehouse FromWarehouse { get; set; }

    public int ToWarehouseId { get; set; }
    [ForeignKey("ToWarehouseId")]
    public Warehouse ToWarehouse { get; set; }


    // Navigation Property
    public ICollection<TransformVoucherItem> TransformItems { get; set; } = new List<TransformVoucherItem>();
    public string TenantId { get; set; } = null!;

  }
}

