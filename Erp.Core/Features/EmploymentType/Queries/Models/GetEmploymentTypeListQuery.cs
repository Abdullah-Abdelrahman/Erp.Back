using Erp.Core.Features.EmploymentType.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.EmploymentType.Queries.Models
{
  public class GetEmploymentTypeListQuery : IRequest<Response<List<GetEmploymentTypeByIdResult>>>
  {
  }
}
