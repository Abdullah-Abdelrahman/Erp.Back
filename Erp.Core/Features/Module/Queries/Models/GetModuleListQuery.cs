using Erp.Core.Features.Module.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Module.Queries.Models
{
  public class GetModuleListQuery : IRequest<Response<List<GetModuleByIdResult>>>
  {
  }
}
