using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.CreditNote.Commands.Models
{
  public class DeleteCreditNoteCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public DeleteCreditNoteCommand(int id)
    {
      Id = id;
    }

  }
}
