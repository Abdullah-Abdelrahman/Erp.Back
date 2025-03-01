using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.JobType.Commands.Models
{
  public class DeleteJobTypeCommand : IRequest<Response<string>>
  {
    public int JobTypeId { get; set; }

    public DeleteJobTypeCommand(int id)
    {
      JobTypeId = id;
    }
  }
}
