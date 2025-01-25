using Erp.Data.Entities;
using Entitis = Erp.Data.Entities;

namespace Erp.Core.Features.Warehouses.Queries.Results
{
  public class GetWarehouseByIdResult
  {
    public int WarehouseId { get; set; }
    public string WarehouseName { get; set; } = null!;
    public string? Address { get; set; }

    // Navigation Property
    public ICollection<StockTransaction> StockTransactions { get; set; } = new List<StockTransaction>();
    public ICollection<Entitis.ReceivingVoucher> receivingVouchers { get; set; } = new List<Entitis.ReceivingVoucher>();

    public ICollection<Entitis.DeliveryVoucher> deliveryVouchers { get; set; } = new List<Entitis.DeliveryVoucher>();
  }
}
