using Erp.Data.Dto.DebitNote;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.DebitNote.Queries.Models
{
  public class GetDebitNoteByIdQuery : IRequest<Response<GetDebitNoteByIdDto>>
  {
    public int Id { get; set; }

    public GetDebitNoteByIdQuery(int id)
    {
      Id = id;
    }
  }
}
