namespace Erp.Core.Features.Payment.Queries.Results
{
  public class GetSupplierPaymentByIdResult
  {
    public int Id { get; set; }

    public string PaymentMethod { get; set; } = "Cash";

    public decimal Amount { get; set; } = 0.0M;

    public DateTime? CreatedDate { get; set; }

    public string AddedById { get; set; } = null!;

    public int treasuryId { get; set; }

    public int JournalEntryID { get; set; }

    public string Currency { get; set; } = null!;


    //suplier Payment only
    public int SupplierId { get; set; }

    public int PurchaseInvoiceId { get; set; }

    public string SupplierName { get; set; } = null!;

    public string? City { get; set; }
    public string? State { get; set; }

    public string? Country { get; set; }

    public string? PostalCode { get; set; }

    public string? Telephone { get; set; }

  }
}
