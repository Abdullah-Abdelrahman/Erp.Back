using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Category.Commands.Models
{
  public class AddCategoryCommand : IRequest<Response<string>>
  {

    public string CategoryName { get; set; } = null!;


  }
}
