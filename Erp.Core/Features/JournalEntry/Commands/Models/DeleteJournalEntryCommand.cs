using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.JournalEntry.Commands.Models
{
  public class DeleteJournalEntryCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public DeleteJournalEntryCommand(int id)
    {
      Id = id;
    }

  }
}
