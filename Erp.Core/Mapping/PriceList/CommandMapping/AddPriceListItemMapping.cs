using Erp.Core.Features.PriceList.Commands.Models;
using E = Erp.Data.Entities.InventoryModule;
namespace Erp.Core.Mapping.PriceList
{
  public partial class PriceListProfile
  {
    public void AddPriceListItemMapping()
    {
      CreateMap<AddPriceListItemCommand, E.PriceListItem>()
     .ForMember(destnation => destnation.ProductId, opt => opt.MapFrom(src => src.ProductId))
 .ForMember(destnation => destnation.PriceListId, opt => opt.MapFrom(src => src.PriceListId))
 .ForMember(destnation => destnation.SellPrice, opt => opt.MapFrom(src => src.SellPrice));
    }
  }
}
