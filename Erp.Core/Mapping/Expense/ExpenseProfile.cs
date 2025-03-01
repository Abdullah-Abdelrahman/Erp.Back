using AutoMapper;

namespace Erp.Core.Mapping.Expense
{
  public partial class ExpenseProfile : Profile
  {
    public ExpenseProfile()
    {
      AddExpenseMapping();
    }
  }
}
