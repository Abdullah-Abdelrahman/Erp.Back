using AutoMapper;

namespace Erp.Core.Mapping.StockTaking
{
  public partial class StockTakingProfile : Profile
  {
    public StockTakingProfile()
    {
      AddStockTakingMapping();
      AddStockTakingItemMapping();

      GetStockTakingByIdMapping();
      GetStockTakingListMapping();
    }
  }
}
