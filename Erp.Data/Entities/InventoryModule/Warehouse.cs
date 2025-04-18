using Erp.Data.Entities.AccountsModule;
using System.Text.Json.Serialization;

namespace Erp.Data.Entities.InventoryModule
{
  public class Warehouse : IMustHaveTenant
  {
    public int WarehouseId { get; set; }
    public string WarehouseName { get; set; } = null!;
    public string? Address { get; set; }

    public int AccountId { get; set; }

    public SecondaryAccount Account { get; set; } = null!;

    public bool IsPrimary { get; set; } = false;

    // Navigation Property
    public ICollection<StockTransaction> StockTransactions { get; set; } = new List<StockTransaction>();

    [JsonIgnore]
    public ICollection<ReceivingVoucher> receivingVouchers { get; set; } = new List<ReceivingVoucher>();

    [JsonIgnore]
    public ICollection<DeliveryVoucher> deliveryVouchers { get; set; } = new List<DeliveryVoucher>();
    public string TenantId { get; set; } = null!;
  }

}
