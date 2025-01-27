using Erp.Core.Features.Category.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Category.Queries.Models
{
  public class GetCategoryListQuery : IRequest<Response<List<GetCategoryByIdResult>>>
  {
  }
}
