namespace Erp.Data.Entities
{
    public class SalesOrder
    {
        public int SalesOrderId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Pending"; // e.g., "Pending", "Completed", "Cancelled"
        public string? Notes { get; set; }

        // Foreign Key - Customer
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        // Navigation Property
        public ICollection<SalesOrderItem> SalesOrderItems { get; set; } = new List<SalesOrderItem>();
    }

}
