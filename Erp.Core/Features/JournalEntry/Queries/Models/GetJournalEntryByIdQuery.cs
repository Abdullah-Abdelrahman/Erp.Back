using Erp.Data.Dto.JournalEntry;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.JournalEntry.Queries.Models
{
  public class GetJournalEntryByIdQuery : IRequest<Response<GetJournalEntryByIdDto>>
  {
    public int Id { get; set; }

    public GetJournalEntryByIdQuery(int id)
    {
      Id = id;
    }
  }
}
