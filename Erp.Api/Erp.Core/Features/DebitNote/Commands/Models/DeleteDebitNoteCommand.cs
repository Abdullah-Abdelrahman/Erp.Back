using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.DebitNote.Commands.Models
{
  public class DeleteDebitNoteCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public DeleteDebitNoteCommand(int id)
    {
      Id = id;
    }

  }
}
