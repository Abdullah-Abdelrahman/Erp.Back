using Erp.Core.Features.CostCenter.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.CostCenter.Queries.Models
{
  public class GetPrimaryCostCenterByIdQuery : IRequest<Response<GetPrimaryCostCenterByIdResult>>
  {
    public int Id { get; set; }

    public GetPrimaryCostCenterByIdQuery(int id)
    {
      Id = id;
    }
  }
}
