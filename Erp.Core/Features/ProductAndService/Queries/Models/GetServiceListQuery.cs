using Erp.Core.Features.ProductAndService.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.ProductAndService.Queries.Models
{
  public class GetServiceListQuery : IRequest<Response<List<GetServiceByIdResult>>>
  {
  }
}
