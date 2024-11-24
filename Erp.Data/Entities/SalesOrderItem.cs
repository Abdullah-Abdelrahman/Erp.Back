using Name.Data.Entities;

namespace Erp.Data.Entities
{
    public class SalesOrderItem
    {
        public int SalesOrderItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;

        // Foreign Keys
        public int SalesOrderId { get; set; }
        public SalesOrder SalesOrder { get; set; } = null!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }

}
