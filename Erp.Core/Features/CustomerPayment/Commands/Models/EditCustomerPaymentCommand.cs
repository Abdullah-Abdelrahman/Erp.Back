using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.CustomerPayment.Commands.Models
{
  public class EditCustomerPaymentCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }

    public int InvoiceId { get; set; }

    public string CustomerId { get; set; }
    public string PaymentStatus { get; set; }


    public DateTime PaymentDate { get; set; }


    public decimal AmountPaid { get; set; }


    public string PaymentMethod { get; set; }

    public string Notes { get; set; } = string.Empty;

    //رقم تعريفي يصاحب عمليات السداد بأوراق الدفع (مثل الشيكات).

    public string? IDNumber { get; set; }
  }
}
