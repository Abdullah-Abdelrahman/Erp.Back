using Erp.Data.Dto.JournalEntry;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.JournalEntry.Commands.Models
{
  public class AddJournalEntryCommand : AddJournalEntryRequest, IRequest<Response<string>>
  {

  }
}
