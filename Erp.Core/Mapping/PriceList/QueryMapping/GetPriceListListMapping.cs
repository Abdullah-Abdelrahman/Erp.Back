using Erp.Core.Features.PriceList.Queries.Results;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Mapping.PriceList
{
  public partial class PriceListProfile
  {
    public void GetPriceListListMapping()
    {
      CreateMap<Entitis.InventoryModule.PriceList, GetPriceListListResult>().
   ForMember(destnation => destnation.PriceListId, opt => opt.MapFrom(src => src.Id)).ForMember(destnation => destnation.PriceListName, opt => opt.MapFrom(src => src.Name))
   .ForMember(destnation => destnation.IsActive, opt => opt.MapFrom(src => src.IsActive))
   .ForMember(destnation => destnation.NumberOfProducts, opt => opt.MapFrom(src => src.priceListItems.Count()));

    }
  }
}
