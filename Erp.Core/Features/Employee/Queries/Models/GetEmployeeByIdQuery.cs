using Erp.Core.Features.Employee.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Employee.Queries.Models
{
  public class GetEmployeeByIdQuery : IRequest<Response<GetEmployeeByIdResult>>
  {
    public int Id { get; set; }

    public GetEmployeeByIdQuery(int id)
    {
      Id = id;
    }
  }
}
