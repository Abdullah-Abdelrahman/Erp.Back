using Erp.Core.Features.EmploymentType.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.EmploymentType.Queries.Models
{
  public class GetEmploymentTypeByIdQuery : IRequest<Response<GetEmploymentTypeByIdResult>>
  {
    public int Id { get; set; }

    public GetEmploymentTypeByIdQuery(int id)
    {
      Id = id;
    }
  }
}
