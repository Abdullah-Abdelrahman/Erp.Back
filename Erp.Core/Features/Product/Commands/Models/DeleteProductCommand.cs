  using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Product.Commands.Models
{
  public class DeleteProductCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public DeleteProductCommand(int id)
    {
      Id = id;
    }
  }
}
