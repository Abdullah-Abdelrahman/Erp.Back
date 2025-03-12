using Erp.Core.Features.Module.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Module.Queries.Models
{
  public class GetModuleByIdQuery : IRequest<Response<GetModuleByIdResult>>
  {
    public int Id { get; set; }

    public GetModuleByIdQuery(int id)
    {
      Id = id;
    }
  }
}
