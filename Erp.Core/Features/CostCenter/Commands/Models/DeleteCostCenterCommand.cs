using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.CostCenter.Commands.Models
{
  public class DeleteCostCenterCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public DeleteCostCenterCommand(int id)
    {
      Id = id;
    }
  }
}
