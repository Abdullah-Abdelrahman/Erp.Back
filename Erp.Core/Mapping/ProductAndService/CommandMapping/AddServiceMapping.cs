using Erp.Core.Features.ProductAndService.Commands.Models;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Mapping.ProductAndService
{
  public partial class ProductAndServiceProfile
  {
    public void AddServiceMapping()
    {
      CreateMap<AddServiceCommand, Entitis.InventoryModule.Service>()
        .ForMember(destnation => destnation.Description, opt => opt.MapFrom(src => src.Description)).ForMember(destnation => destnation.Name, opt => opt.MapFrom(src => src.ServiceName)).ForMember(destnation => destnation.Status, opt => opt.MapFrom(src => src.Status));
    }
  }
}
