using AutoMapper;

namespace Erp.Core.Mapping.PriceList
{
  public partial class PriceListProfile : Profile
  {
    public PriceListProfile()
    {
      AddPriceListMapping();
      AddPriceListItemMapping();

      GetPriceListByIdMapping();
      GetPriceListListMapping();
    }
  }
}
