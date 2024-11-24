using Erp.Data.Entities;

namespace Name.Data.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        // Navigation Property
        public ICollection<StockTransaction> StockTransactions { get; set; } = new List<StockTransaction>();
    }

}
