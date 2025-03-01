using Erp.Core.Features.CostCenter.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.CostCenter.Queries.Models
{
  public class GetPrimaryCostCentersListQuery : IRequest<Response<List<GetPrimaryCostCenterByIdResult>>>
  {
  }
}
