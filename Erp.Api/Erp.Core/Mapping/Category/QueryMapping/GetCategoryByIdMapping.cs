using Erp.Core.Features.Category.Queries.Results;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Mapping.Category
{
  public partial class CategoryProfile
  {

    public void GetCategoryByIdMapping()
    {
      CreateMap<Entitis.Category, GetCategoryByIdResult>().
     ForMember(destnation => destnation.CategoryId, opt => opt.MapFrom(src => src.CategoryId)).ForMember(destnation => destnation.CategoryName, opt => opt.MapFrom(src => src.CategoryName));


    }
  }
}
