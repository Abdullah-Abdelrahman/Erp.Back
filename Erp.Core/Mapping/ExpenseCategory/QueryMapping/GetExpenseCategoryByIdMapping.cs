using Erp.Core.Features.ExpenseCategory.Queries.Results;
using Entitis = Erp.Data.Entities.Finance;
namespace Erp.Core.Mapping.ExpenseCategory
{
  public partial class ExpenseCategoryProfile
  {

    public void GetExpenseCategoryByIdMapping()
    {
      CreateMap<Entitis.ExpenseCategory, GetExpenseCategoryByIdResult>().
     ForMember(destnation => destnation.Id, opt => opt.MapFrom(src => src.Id)).ForMember(destnation => destnation.Name, opt => opt.MapFrom(src => src.Name));


    }
  }
}
