using Erp.Data.Dto.JournalEntry;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.JournalEntry.Queries.Models
{
  public class GetJournalEntryListQuery : IRequest<Response<List<GetJournalEntryByIdDto>>>
  {
  }
}
