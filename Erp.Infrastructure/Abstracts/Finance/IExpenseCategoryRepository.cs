using Erp.Data.Entities.Finance;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.Finance
{
  public interface IExpenseCategoryRepository : IGenericRepository<ExpenseCategory>
  {
    public Task<string> AddExpenseCategoryAsync(ExpenseCategory ExpenseCategory);

    public Task<ExpenseCategory?> GetExpenseCategoryByIdAsync(int id);

    public Task<List<ExpenseCategory>> GetExpenseCategorysListAsync();

    public Task<string> UpdateExpenseCategoryAsync(ExpenseCategory request);
  }
}
