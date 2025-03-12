using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.CompanyModule.Commands.Models
{
  public class DeActivateModuleCommand : IRequest<Response<string>>
  {
    public int ModelId { get; set; }

    public DeActivateModuleCommand(int id)
    {
      ModelId = id;
    }
  }
}
