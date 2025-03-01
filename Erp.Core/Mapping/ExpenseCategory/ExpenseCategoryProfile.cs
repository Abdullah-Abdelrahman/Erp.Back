using AutoMapper;

namespace Erp.Core.Mapping.ExpenseCategory
{
  public partial class ExpenseCategoryProfile : Profile
  {
    public ExpenseCategoryProfile()
    {
      AddExpenseCategoryMapping();
      EditExpenseCategoryMapping();

      GetExpenseCategoryByIdMapping();
    }
  }
}
