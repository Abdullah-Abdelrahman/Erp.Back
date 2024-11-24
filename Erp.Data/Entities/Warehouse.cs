using Erp.Data.Entities;

namespace Name.Data.Entities
{
    public class Warehouse
    {
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; } = null!;
        public string? Address { get; set; }

        // Navigation Property
        public ICollection<StockTransaction> StockTransactions { get; set; } = new List<StockTransaction>();
    }

}
