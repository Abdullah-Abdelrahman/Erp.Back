using AutoMapper;

namespace Erp.Core.Mapping.Quotation
{
  public partial class QuotationProfile : Profile
  {
    public QuotationProfile()
    {
      AddQuotationMapping();
    }
  }
}
