using Erp.Data.Dto.DebitNote;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.DebitNote.Commands.Models
{
  public class EditDebitNoteCommand : UpdateDebitNoteRequest, IRequest<Response<string>>
  {


  }
}
