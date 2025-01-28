using AutoMapper;

namespace Erp.Core.Mapping.JournalEntry
{
  public partial class JournalEntryProfile : Profile
  {
    public JournalEntryProfile()
    {
      AddJournalEntryMapping();
    }
  }
}
