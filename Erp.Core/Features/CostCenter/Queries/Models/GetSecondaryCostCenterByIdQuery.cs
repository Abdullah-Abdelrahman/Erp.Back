using Erp.Core.Features.CostCenter.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.CostCenter.Queries.Models
{
  public class GetSecondaryCostCenterByIdQuery : IRequest<Response<GetSecondaryCostCenterByIdResult>>
  {
    public int Id { get; set; }

    public GetSecondaryCostCenterByIdQuery(int id)
    {
      Id = id;
    }
  }
}
