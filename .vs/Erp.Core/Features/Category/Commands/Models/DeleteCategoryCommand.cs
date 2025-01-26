using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Category.Commands.Models
{
  public class DeleteCategoryCommand : IRequest<Response<string>>
  {
    public int CategoryId { get; set; }

    public DeleteCategoryCommand(int id)
    {
      CategoryId = id;
    }
  }
}
