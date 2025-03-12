using Erp.Core.Features.StockTaking.Queries.Results;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Mapping.StockTaking
{
  public partial class StockTakingProfile
  {

    public void GetStockTakingByIdMapping()
    {
      CreateMap<Entitis.InventoryModule.StockTaking, GetStockTakingByIdResult>().
     ForMember(destnation => destnation.Id, opt => opt.MapFrom(src => src.Id))
     .ForMember(destnation => destnation.StockTakingItems, opt => opt.MapFrom(src => src.stockTakingItems));

      CreateMap<Entitis.InventoryModule.StockTakingItem, StockTakingItemDto>().
  ForMember(destnation => destnation.ProductId, opt => opt.MapFrom(src => src.ProductId));
    }
  }
}
