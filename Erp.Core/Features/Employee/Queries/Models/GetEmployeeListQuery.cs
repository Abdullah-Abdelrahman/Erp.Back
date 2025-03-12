using Erp.Core.Features.Employee.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Employee.Queries.Models
{
  public class GetEmployeeListQuery : IRequest<Response<List<GetEmployeeByIdResult>>>
  {
  }
}
