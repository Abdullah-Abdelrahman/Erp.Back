using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Category.Commands.Models
{
  public class EditCategoryCommand : IRequest<Response<string>>
  {
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;
  }
}
