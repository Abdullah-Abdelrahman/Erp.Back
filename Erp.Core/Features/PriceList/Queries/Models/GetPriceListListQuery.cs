using Erp.Core.Features.PriceList.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.PriceList.Queries.Models
{
  public class GetPriceListListQuery : IRequest<Response<List<GetPriceListListResult>>>
  {
  }
}
