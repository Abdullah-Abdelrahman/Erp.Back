using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Treasury.Commands.Models
{
  public class DeleteTreasuryCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public DeleteTreasuryCommand(int id)
    {
      Id = id;
    }

  }
}
