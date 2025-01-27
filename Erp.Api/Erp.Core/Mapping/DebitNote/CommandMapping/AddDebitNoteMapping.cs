using Erp.Core.Features.DebitNote.Commands.Models;
using Erp.Data.Dto.DebitNote;

namespace Erp.Core.Mapping.DebitNote
{
  public partial class DebitNoteProfile
  {
    public void AddDebitNoteMapping()
    {
      CreateMap<AddDebitNoteCommand, AddDebitNoteRequest>()
        .ForMember(destnation => destnation.DebitNoteItemDT0s, opt => opt.MapFrom(src => src.DebitNoteItemDT0s));
    }
  }
}
