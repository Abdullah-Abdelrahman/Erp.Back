using Erp.Core.Features.Product.Commands.Models;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Mapping.Product
{
  public partial class ProductProfile
  {
    public void AddProductMapping()
    {
      CreateMap<AddProductCommand, Entitis.InventoryModule.Product>()
        .ForMember(destnation => destnation.Description, opt => opt.MapFrom(src => src.Description))
        .ForMember(destnation => destnation.Name, opt => opt.MapFrom(src => src.ProductName));
    }
  }
}
