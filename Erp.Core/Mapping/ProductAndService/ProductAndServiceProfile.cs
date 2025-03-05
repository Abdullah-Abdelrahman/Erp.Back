using AutoMapper;

namespace Erp.Core.Mapping.ProductAndService
{
  public partial class ProductAndServiceProfile : Profile
  {
    public ProductAndServiceProfile()
    {
      AddServiceMapping();



      GetServiceByIdMapping();
    }
  }
}
