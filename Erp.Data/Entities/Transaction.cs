namespace Name.Data.Entities
{
    public class Transaction
    {
        public int TransactionID { get; set; }

        public int CompanyID { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

        public string? Description { get; set; }

        public decimal TotalAmount { get; set; }

        // Navigation property
        public Company Company { get; set; } = null!;
    }

}
