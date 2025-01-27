using AutoMapper;

namespace Erp.Core.Mapping.Category
{
  public partial class CategoryProfile : Profile
  {
    public CategoryProfile()
    {
      AddCategoryMapping();

      GetCategoryByIdMapping();
    }
  }
}
