using Erp.Core.Features.Product.Queries.Results;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Mapping.Product
{
  public partial class ProductProfile
  {
    public void GetProductByIdMapping()
    {
      CreateMap<Entitis.InventoryModule.Product, GetProductByIdResult>().
        ForMember(destnation => destnation.categories, opt => opt.MapFrom(src => src.categories));

    }
  }
}
