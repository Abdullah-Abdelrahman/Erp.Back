using Erp.Core.Features.ExpenseCategory.Commands.Models;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Mapping.ExpenseCategory
{
  public partial class ExpenseCategoryProfile
  {
    public void EditExpenseCategoryMapping()
    {
      CreateMap<EditExpenseCategoryCommand, Entitis.Finance.ExpenseCategory>()
   .ForMember(destnation => destnation.Name, opt => opt.MapFrom(src => src.Name));
    }
  }
}
