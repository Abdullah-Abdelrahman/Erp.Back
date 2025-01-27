using Erp.Core.Features.Category.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Category.Queries.Models
{
  public class GetCategoryByIdQuery : IRequest<Response<GetCategoryByIdResult>>
  {
    public int Id { get; set; }

    public GetCategoryByIdQuery(int id)
    {
      Id = id;
    }
  }
}
