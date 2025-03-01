using Erp.Data.Entities.Finance;

namespace Erp.Service.Abstracts.Finance
{
  public interface IExpenseCategoryService
  {
    public Task<List<ExpenseCategory>> GetExpenseCategorysListAsync();

    public Task<ExpenseCategory> GetExpenseCategoryByIdAsync(int id);

    public Task<string> AddExpenseCategoryAsync(ExpenseCategory ExpenseCategory);

    public Task<string> UpdateAsync(ExpenseCategory ExpenseCategory);

    public Task<string> DeleteAsync(ExpenseCategory ExpenseCategory);
  }
}
