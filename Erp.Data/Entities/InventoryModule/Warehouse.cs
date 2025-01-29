using System.Text.Json.Serialization;

namespace Erp.Data.Entities.InventoryModule
{
  public class Warehouse
  {
    public int WarehouseId { get; set; }
    public string WarehouseName { get; set; } = null!;
    public string? Address { get; set; }

    // Navigation Property
    public ICollection<StockTransaction> StockTransactions { get; set; } = new List<StockTransaction>();

    [JsonIgnore]
    public ICollection<ReceivingVoucher> receivingVouchers { get; set; } = new List<ReceivingVoucher>();

    [JsonIgnore]
    public ICollection<DeliveryVoucher> deliveryVouchers { get; set; } = new List<DeliveryVoucher>();

  }

}
