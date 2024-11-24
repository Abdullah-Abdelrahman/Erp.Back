namespace Erp.Data.Entities
{
    public class ReceivingVoucher
    {
        public int ReceivingVoucherId { get; set; }
        public DateTime ReceivingDate { get; set; } = DateTime.UtcNow;
        public string? Notes { get; set; }

        // Foreign Keys
        public int PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; } = null!;
    }

}
