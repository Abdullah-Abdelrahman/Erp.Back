using Erp.Core.Features.JobType.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.JobType.Queries.Models
{
  public class GetJobTypeByIdQuery : IRequest<Response<GetJobTypeByIdResult>>
  {
    public int Id { get; set; }

    public GetJobTypeByIdQuery(int id)
    {
      Id = id;
    }
  }
}
