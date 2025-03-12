using Erp.Core.Features.PriceList.Commands.Models;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Mapping.PriceList
{
  public partial class PriceListProfile
  {

    public void AddPriceListMapping()
    {
      CreateMap<AddPriceListCommand, Entitis.InventoryModule.PriceList>()
       .ForMember(destnation => destnation.Name, opt => opt.MapFrom(src => src.PriceListName))
   .ForMember(destnation => destnation.IsActive, opt => opt.MapFrom(src => src.IsActive));
    }
  }
}
