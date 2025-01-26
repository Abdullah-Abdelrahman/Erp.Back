using Erp.Data.Dto.DebitNote;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.DebitNote.Queries.Models
{
  public class GetDebitNoteListQuery : IRequest<Response<List<GetDebitNoteByIdDto>>>
  {
  }
}
