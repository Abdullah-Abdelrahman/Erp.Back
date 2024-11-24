namespace Erp.Data.Entities
{
    public class PurchaseOrder
    {
        public int PurchaseOrderId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Pending"; // e.g., "Pending", "Completed", "Cancelled"
        public string? Notes { get; set; }

        // Foreign Key - Supplier
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;

        // Navigation Property
        public ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>();
    }

}
