using Erp.Core.Features.Department.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Department.Queries.Models
{
  public class GetDepartmentListQuery : IRequest<Response<List<GetDepartmentByIdResult>>>
  {
  }
}
