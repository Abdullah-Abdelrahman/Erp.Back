using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Module.Commands.Models
{
  public class DeleteModuleCommand : IRequest<Response<string>>
  {
    public int ModuleId { get; set; }

    public DeleteModuleCommand(int id)
    {
      ModuleId = id;
    }
  }
}
