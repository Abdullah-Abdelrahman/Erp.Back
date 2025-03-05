using Erp.Core.Features.ProductAndService.Queries.Results;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Mapping.ProductAndService
{
  public partial class ProductAndServiceProfile
  {
    public void GetServiceByIdMapping()
    {
      CreateMap<Entitis.InventoryModule.Service, GetServiceByIdResult>().
        ForMember(destnation => destnation.ServiceId, opt => opt.MapFrom(src => src.ProductId)).
        ForMember(destnation => destnation.ServiceName, opt => opt.MapFrom(src => src.Name)).
        ForMember(destnation => destnation.Status, opt => opt.MapFrom(src => src.Status));

    }
  }
}
