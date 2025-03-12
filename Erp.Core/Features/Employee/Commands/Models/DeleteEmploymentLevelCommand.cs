using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Employee.Commands.Models
{
  public class DeleteEmployeeCommand : IRequest<Response<string>>
  {
    public int EmployeeId { get; set; }

    public DeleteEmployeeCommand(int id)
    {
      EmployeeId = id;
    }
  }
}
