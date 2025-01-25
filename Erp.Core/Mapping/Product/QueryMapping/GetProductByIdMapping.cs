using Erp.Core.Features.Product.Queries.Results;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Mapping.Product
{
  public partial class ProductProfile
  {
    public void GetProductByIdMapping()
    {
      CreateMap<Entitis.Product, GetProductByIdResult>().
        ForMember(destnation => destnation.CategoryId, opt => opt.MapFrom(src => src.Category.CategoryId)).
        ForMember(destnation => destnation.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName)).ForMember(destnation => destnation.ImageFile, opt => opt.MapFrom(src => src.ImageFile));
    }
  }
}
