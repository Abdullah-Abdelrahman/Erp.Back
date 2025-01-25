namespace Erp.Data.Entities
{
  public class TransactionDetail
  {
    public int TransactionDetailID { get; set; }

    public int TransactionID { get; set; }

    public int AccountID { get; set; }

    public decimal Debit { get; set; } = 0.00m;

    public decimal Credit { get; set; } = 0.00m;

    // Navigation properties
    public Transaction Transaction { get; set; } = null!;

    public Account Account { get; set; } = null!;
  }

}
