using Erp.Data.Entities.CustomersModule;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.SalesModule
{
  public class Quotation
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

    public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected

    public decimal TotalAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal Discount { get; set; }
    public decimal GrandTotal { get; set; }

    public ICollection<QuotationItem> Items { get; set; } = new List<QuotationItem>();
  }
}
