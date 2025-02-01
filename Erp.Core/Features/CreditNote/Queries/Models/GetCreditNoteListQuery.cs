using Erp.Data.Dto.CreditNote;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.CreditNote.Queries.Models
{
  public class GetCreditNoteListQuery : IRequest<Response<List<GetCreditNoteByIdDto>>>
  {
  }
}
