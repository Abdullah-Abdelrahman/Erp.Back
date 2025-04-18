using Erp.Data.Dto.Quotation;
using Erp.Data.Entities.CustomersModule;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.SalesModule
{
  public class Quotation : IMustHaveTenant
  {
    [Key]
    public int QuotationId { get; set; }

    [Required]
    public DateTime QuoteDate { get; set; }

    public DateTime? ExpiryDate { get; set; }

    [Required]
    public int CustomerId { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public Customer Customer { get; set; } = null!;

    public QuotationStatus Status { get; set; } = 0; // Pending, Approved, Rejected

    public decimal TaxAmount { get; set; }
    public decimal Discount { get; set; }
    public decimal Total { get; set; }

    public ICollection<QuotationItem> Items { get; set; } = new List<QuotationItem>();
    public string TenantId { get; set; } = null!;

    public Quotation(AddQuotationRequest QuotationRequest)
    {
      CustomerId = QuotationRequest.CustomerID;
      QuoteDate = QuotationRequest.QuoteDate;
      ExpiryDate = QuotationRequest.ExpiryDate;
      TaxAmount = QuotationRequest.Tax;
      Discount = QuotationRequest.Discount;
      Total = QuotationRequest.GrandTotal;
      Status = QuotationStatus.Pending;

    }

    public Quotation(UpdateQuotationRequest QuotationRequest)
    {
      QuotationId = QuotationRequest.QuotationId;
      CustomerId = QuotationRequest.CustomerID;
      QuoteDate = QuotationRequest.QuoteDate;
      ExpiryDate = QuotationRequest.ExpiryDate;
      TaxAmount = QuotationRequest.Tax;
      Discount = QuotationRequest.Discount;
      Total = QuotationRequest.GrandTotal;
      Status = QuotationRequest.Status;
    }
    public Quotation()
    {

    }
  }

  public enum QuotationStatus
  {
    Pending, Approved, Rejected
  }
}
