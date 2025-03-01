using Erp.Core.Features.JobType.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.JobType.Queries.Models
{
  public class GetJobTypeListQuery : IRequest<Response<List<GetJobTypeByIdResult>>>
  {
  }
}
