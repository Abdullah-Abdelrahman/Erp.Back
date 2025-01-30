using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Customer.Commands.Models
{
  public class DeleteCustomerCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public DeleteCustomerCommand(int id)
    {
      Id = id;
    }
  }
}
