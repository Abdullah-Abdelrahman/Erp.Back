using Erp.Core.Features.JournalEntry.Commands.Models;
using Erp.Data.Dto.JournalEntry;

namespace Erp.Core.Mapping.JournalEntry
{
  public partial class JournalEntryProfile
  {
    public void AddJournalEntryMapping()
    {
      CreateMap<AddJournalEntryCommand, AddJournalEntryRequest>()
        .ForMember(destnation => destnation.JournalEntryItemDT0s, opt => opt.MapFrom(src => src.JournalEntryItemDT0s));
    }
  }
}
