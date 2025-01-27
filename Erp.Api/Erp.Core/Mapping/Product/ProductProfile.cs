using AutoMapper;

namespace Erp.Core.Mapping.Product
{
  public partial class ProductProfile : Profile
  {
    public ProductProfile()
    {
      AddProductMapping();



      GetProductByIdMapping();
    }
  }
}
