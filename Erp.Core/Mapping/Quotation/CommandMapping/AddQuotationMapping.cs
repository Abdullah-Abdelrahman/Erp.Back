using Erp.Core.Features.Quotation.Commands.Models;
using Erp.Data.Dto.Quotation;

namespace Erp.Core.Mapping.Quotation
{
  public partial class QuotationProfile
  {
    public void AddQuotationMapping()
    {
      CreateMap<AddQuotationCommand, AddQuotationRequest>()
        .ForMember(destnation => destnation.QuotationItemDT0s, opt => opt.MapFrom(src => src.QuotationItemDT0s));
    }
  }
}
