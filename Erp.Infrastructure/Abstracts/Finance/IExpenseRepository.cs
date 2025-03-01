using Erp.Data.Entities.Finance;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.Finance
{
  public interface IExpenseRepository : IGenericRepository<Expense>
  {
    public Task<string> AddExpenseAsync(Expense Expense);

    public Task<Expense?> GetExpenseByIdAsync(int id);

    public Task<List<Expense>> GetExpensesListAsync();

    public Task<string> UpdateExpenseAsync(Expense request);
  }
}
