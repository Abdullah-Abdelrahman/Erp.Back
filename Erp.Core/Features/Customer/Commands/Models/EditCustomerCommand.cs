using Erp.Data.Dto.Customer;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Customer.Commands.Models
{
  public class EditCustomerCommand : UpdateCustomerRequest,
    IRequest<Response<string>>
  {

  }
}
