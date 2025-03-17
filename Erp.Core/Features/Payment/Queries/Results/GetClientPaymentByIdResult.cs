namespace Erp.Core.Features.Payment.Queries.Results
{
  public class GetClientPaymentByIdResult
  {
    public int Id { get; set; }

    public string PaymentMethod { get; set; } = "Cash";

    public decimal Amount { get; set; } = 0.0M;

    public DateTime? CreatedDate { get; set; }

    public string AddedById { get; set; } = null!;

    public int treasuryId { get; set; }

    public int JournalEntryID { get; set; }

    public string Currency { get; set; } = null!;

  }
}
