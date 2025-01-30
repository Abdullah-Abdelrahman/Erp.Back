using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.ContactList.Commands.Models
{
  public class DeleteContactListCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public DeleteContactListCommand(int id)
    {
      Id = id;
    }
  }
}
