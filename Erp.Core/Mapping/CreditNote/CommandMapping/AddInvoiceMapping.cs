using Erp.Core.Features.CreditNote.Commands.Models;
using Erp.Data.Dto.CreditNote;

namespace Erp.Core.Mapping.CreditNote
{
  public partial class CreditNoteProfile
  {
    public void AddCreditNoteMapping()
    {
      CreateMap<AddCreditNoteCommand, AddCreditNoteRequest>()
        .ForMember(destnation => destnation.CreditNoteItemDT0s, opt => opt.MapFrom(src => src.CreditNoteItemDT0s));
    }
  }
}
