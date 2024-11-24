namespace Erp.Data.Entities
{
    public class DeliveryVoucher
    {
        public int DeliveryVoucherId { get; set; }
        public DateTime DeliveryDate { get; set; } = DateTime.UtcNow;
        public string? Notes { get; set; }

        // Foreign Keys
        public int SalesOrderId { get; set; }
        public SalesOrder SalesOrder { get; set; } = null!;
    }

}
