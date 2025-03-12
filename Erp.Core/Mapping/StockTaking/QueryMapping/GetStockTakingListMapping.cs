using Erp.Core.Features.StockTaking.Queries.Results;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Mapping.StockTaking
{
  public partial class StockTakingProfile
  {
    public void GetStockTakingListMapping()
    {
      CreateMap<Entitis.InventoryModule.StockTaking, GetStockTakingListResult>().
   ForMember(destnation => destnation.Id, opt => opt.MapFrom(src => src.Id))
   .ForMember(destnation => destnation.Date, opt => opt.MapFrom(src => src.Date))
   .ForMember(destnation => destnation.Description, opt => opt.MapFrom(src => src.Description));

    }
  }
}
