using Erp.Core.Features.StockTaking.Commands.Models;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Mapping.StockTaking
{
  public partial class StockTakingProfile
  {

    public void AddStockTakingMapping()
    {
      CreateMap<AddStockTakingCommand, Entitis.InventoryModule.StockTaking>()
        .ForMember(destnation => destnation.Description, opt => opt.MapFrom(src => src.Description))
        .ForMember(destnation => destnation.Date, opt => opt.MapFrom(src => src.Date));

    }
  }
}
