using Erp.Core.Features.Expense.Commands.Models;
using Erp.Data.Dto.Expense;

namespace Erp.Core.Mapping.Expense
{
  public partial class ExpenseProfile
  {
    public void AddExpenseMapping()
    {
      CreateMap<AddExpenseCommand, AddExpenseRequest>()
        .ForMember(destnation => destnation.expenseCostCenterDtos, opt => opt.MapFrom(src => src.expenseCostCenterDtos));
    }
  }
}
