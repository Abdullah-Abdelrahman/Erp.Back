using System.ComponentModel.DataAnnotations;

namespace Erp.Core.Features.CustomerPayment.Queries.Results
{
  public class GetCustomerPaymentByIdResult
  {
    public int Id { get; set; }

    public int InvoiceId { get; set; }

    public string CustomerId { get; set; }
    public string PaymentStatus { get; set; }


    public DateTime PaymentDate { get; set; }

    [Required]
    public decimal AmountPaid { get; set; }

    [Required]
    public string PaymentMethod { get; set; }

    public string Notes { get; set; } = string.Empty;

    //رقم تعريفي يصاحب عمليات السداد بأوراق الدفع (مثل الشيكات).

    public string? IDNumber { get; set; }

  }
}
