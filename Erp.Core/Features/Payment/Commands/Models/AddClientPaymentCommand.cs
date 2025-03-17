using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Payment.Commands.Models
{
  public class AddClientPaymentCommand : IRequest<Response<string>>
  {
  }
}
