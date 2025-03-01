using Erp.Core.Features.EmploymentLevel.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.EmploymentLevel.Queries.Models
{
  public class GetEmploymentLevelListQuery : IRequest<Response<List<GetEmploymentLevelByIdResult>>>
  {
  }
}
