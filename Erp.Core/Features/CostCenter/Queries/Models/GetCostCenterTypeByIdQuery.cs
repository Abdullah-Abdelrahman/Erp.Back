using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.CostCenter.Queries.Models
{
  public class GetCostCenterTypeByIdQuery : IRequest<Response<string>>
  {
    public int Id { get; set; }

    public GetCostCenterTypeByIdQuery(int id)
    {
      Id = id;
    }
  }
}
