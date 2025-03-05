using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.CustomerClassification.Commands.Models
{
  public class DeleteCustomerClassificationCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }

    public DeleteCustomerClassificationCommand(int id)
    {
      Id = id;
    }
  }
}
