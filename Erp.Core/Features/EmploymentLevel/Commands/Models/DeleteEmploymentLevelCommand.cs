using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.EmploymentLevel.Commands.Models
{
  public class DeleteEmploymentLevelCommand : IRequest<Response<string>>
  {
    public int EmploymentLevelId { get; set; }

    public DeleteEmploymentLevelCommand(int id)
    {
      EmploymentLevelId = id;
    }
  }
}
