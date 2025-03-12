using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.CompanyModule.Commands.Models
{
  public class ActivateModuleCommand : IRequest<Response<string>>
  {

    public int ModelId { get; set; }

    public ActivateModuleCommand(int id)
    {
      ModelId = id;
    }

  }
}
