using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.InventoryModule
{
  public class StockTransaction : IMustHaveTenant
  {
    public int StockTransactionId { get; set; }
    public string TransactionType { get; set; } = null!;
    // e.g., "SALE", "PURCHASE", "ADJUSTMENT"
    public int Quantity { get; set; }
    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

    // Foreign Keys
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public ProductAndServiceBase Product { get; set; } = null!;

    public int WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; } = null!;
    public string TenantId { get; set; } = null!;

  }

}
