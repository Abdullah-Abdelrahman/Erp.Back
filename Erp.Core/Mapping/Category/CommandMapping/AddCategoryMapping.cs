using Erp.Core.Features.Category.Commands.Models;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Mapping.Category
{
  public partial class CategoryProfile
  {

    public void AddCategoryMapping()
    {
      CreateMap<AddCategoryCommand, Entitis.InventoryModule.Category>()
       .ForMember(destnation => destnation.CategoryName, opt => opt.MapFrom(src => src.CategoryName))
       .ForMember(destnation => destnation.ImageFile, opt => opt.Ignore());
    }
  }
}
