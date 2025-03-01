using Erp.Data.Dto.Expense;
using Erp.Data.Entities.Finance;

namespace Erp.Service.Abstracts.Finance
{
  public interface IExpenseService
  {
    public Task<List<GetExpenseByIdDto>> GetExpensesListAsync();

    public Task<GetExpenseByIdDto> GetExpenseByIdAsync(int id);

    public Task<string> AddExpense(AddExpenseRequest Expense);

    public Task<string> UpdateAsync(UpdateExpenseRequest Expense);

    public Task<string> DeleteAsync(Expense Expense);
    public Task<string> DeleteByIdAsync(int id);
  }
}
