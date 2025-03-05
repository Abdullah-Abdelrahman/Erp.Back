using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.ProductAndService.Commands.Models
{
  public class DeleteServiceCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public DeleteServiceCommand(int id)
    {
      Id = id;
    }
  }

}
