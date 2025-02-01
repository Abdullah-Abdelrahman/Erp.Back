using Erp.Data.Dto.CreditNote;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.CreditNote.Commands.Models
{
  public class EditCreditNoteCommand : UpdateCreditNoteRequest, IRequest<Response<string>>
  {


  }
}
