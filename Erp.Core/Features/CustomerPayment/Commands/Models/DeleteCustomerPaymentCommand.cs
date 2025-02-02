using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.CustomerPayment.Commands.Models
{
  public class DeleteCustomerPaymentCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public DeleteCustomerPaymentCommand(int id)
    {
      Id = id;
    }
  }
}
