using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Account.Commands.Models
{
  public class DeleteAccountCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public DeleteAccountCommand(int id)
    {
      Id = id;
    }
  }
}
