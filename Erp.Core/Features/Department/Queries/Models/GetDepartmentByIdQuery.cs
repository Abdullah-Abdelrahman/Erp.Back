using Erp.Core.Features.Department.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Department.Queries.Models
{
  public class GetDepartmentByIdQuery : IRequest<Response<GetDepartmentByIdResult>>
  {
    public int Id { get; set; }

    public GetDepartmentByIdQuery(int id)
    {
      Id = id;
    }
  }
}
