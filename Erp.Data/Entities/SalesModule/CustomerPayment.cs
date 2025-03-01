using Erp.Data.Entities.CustomersModule;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.SalesModule
{
  public class CustomerPayment : IMustHaveTenant
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public int InvoiceId { get; set; }

    [ForeignKey(nameof(InvoiceId))]
    public Invoice Invoice { get; set; } = null!;
    public int CustomerId { get; set; }
    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; }

    public DateTime PaymentDate { get; set; }

    [Required]
    public decimal AmountPaid { get; set; }

    [Required]
    public string PaymentMethod { get; set; }

    public string PaymentStatus { get; set; }

    public string Notes { get; set; } = string.Empty;

    //رقم تعريفي يصاحب عمليات السداد بأوراق الدفع (مثل الشيكات).

    public string? IDNumber { get; set; }

    public string TenantId { get; set; } = null!;

  }
}
