using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.EmploymentType.Commands.Models
{
  public class DeleteEmploymentTypeCommand : IRequest<Response<string>>
  {
    public int EmploymentTypeId { get; set; }

    public DeleteEmploymentTypeCommand(int id)
    {
      EmploymentTypeId = id;
    }
  }
}
