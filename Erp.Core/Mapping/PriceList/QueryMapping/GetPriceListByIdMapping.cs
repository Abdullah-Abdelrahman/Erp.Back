using Erp.Core.Features.PriceList.Queries.Results;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Mapping.PriceList
{
  public partial class PriceListProfile
  {

    public void GetPriceListByIdMapping()
    {
      CreateMap<Entitis.InventoryModule.PriceList, GetPriceListByIdResult>().
     ForMember(destnation => destnation.PriceListId, opt => opt.MapFrom(src => src.Id)).ForMember(destnation => destnation.PriceListName, opt => opt.MapFrom(src => src.Name))
     .ForMember(destnation => destnation.IsActive, opt => opt.MapFrom(src => src.IsActive))
     .ForMember(destnation => destnation.PriceListItems, opt => opt.MapFrom(src => src.priceListItems));

      CreateMap<Entitis.InventoryModule.PriceListItem, PriceListItemDto>().
  ForMember(destnation => destnation.Product, opt => opt.MapFrom(src => src.Product)).ForMember(destnation => destnation.SellPrice, opt => opt.MapFrom(src => src.SellPrice));
    }
  }
}
