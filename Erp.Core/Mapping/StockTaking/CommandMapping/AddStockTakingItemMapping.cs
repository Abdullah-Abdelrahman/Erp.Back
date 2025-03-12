using Erp.Core.Features.StockTaking.Commands.Models;
using E = Erp.Data.Entities.InventoryModule;
namespace Erp.Core.Mapping.StockTaking
{
  public partial class StockTakingProfile
  {
    public void AddStockTakingItemMapping()
    {
      CreateMap<AddStockTakingItemCommand, E.StockTakingItem>()
     .ForMember(destnation => destnation.ProductId, opt => opt.MapFrom(src => src.ProductId))
     .ForMember(destnation => destnation.StockTakingId, opt => opt.MapFrom(src => src.StockTakingId))
     .ForMember(destnation => destnation.NumberIStock, opt => opt.MapFrom(src => src.NumberIStock))
     .ForMember(destnation => destnation.NumberInProgram, opt => opt.MapFrom(src => src.NumberInProgram))
     .ForMember(destnation => destnation.DecreaseAndExcess, opt => opt.MapFrom(src => src.DecreaseAndExcess));
    }
  }
}
