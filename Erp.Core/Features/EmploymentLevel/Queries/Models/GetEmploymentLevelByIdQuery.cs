using Erp.Core.Features.EmploymentLevel.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.EmploymentLevel.Queries.Models
{
  public class GetEmploymentLevelByIdQuery : IRequest<Response<GetEmploymentLevelByIdResult>>
  {
    public int Id { get; set; }

    public GetEmploymentLevelByIdQuery(int id)
    {
      Id = id;
    }
  }
}
