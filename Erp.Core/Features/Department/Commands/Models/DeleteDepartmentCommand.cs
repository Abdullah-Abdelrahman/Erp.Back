using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Department.Commands.Models
{
  public class DeleteDepartmentCommand : IRequest<Response<string>>
  {
    public int DepartmentId { get; set; }

    public DeleteDepartmentCommand(int id)
    {
      DepartmentId = id;
    }
  }
}
