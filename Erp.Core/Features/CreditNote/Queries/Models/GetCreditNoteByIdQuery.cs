using Erp.Data.Dto.CreditNote;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.CreditNote.Queries.Models
{
  public class GetCreditNoteByIdQuery : IRequest<Response<GetCreditNoteByIdDto>>
  {
    public int Id { get; set; }

    public GetCreditNoteByIdQuery(int id)
    {
      Id = id;
    }
  }
}
