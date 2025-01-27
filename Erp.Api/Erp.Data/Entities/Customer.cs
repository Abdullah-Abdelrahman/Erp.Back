namespace Erp.Data.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string? ContactInfo { get; set; }
        public string? Address { get; set; }
    }

}
