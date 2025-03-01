using Erp.Data.Entities.Finance;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.Finance;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.Finance
{
  public class ExpenseRepository : GenericRepository<Expense>, IExpenseRepository
  {
    private readonly DbSet<Expense> _Expenses;
    public ExpenseRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _Expenses = dbContext.Set<Expense>();

    }


    public async Task<string> AddExpenseAsync(Expense Expense)
    {
      var result = await _Expenses.AddAsync(Expense);

      if (result == null)
      {
        return "Cant Add";
      }
      else
      {
        return MessageCenter.CrudMessage.Success;
      }
    }

    public async Task<Expense?> GetExpenseByIdAsync(int id)
    {
      return await _Expenses
        .Where(x => x.Id == id)
        .Include(x => x.ExpenseCostCenters)
        .Include(x => x.multiAccExpenseItems)
        .Include(x => x.expenseCategories)
        .SingleOrDefaultAsync();

    }

    public async Task<List<Expense>> GetExpensesListAsync()
    {
      return await _Expenses.ToListAsync();
    }

    public async Task<string> UpdateExpenseAsync(Expense request)
    {
      var result = _Expenses.Update(request);

      return MessageCenter.CrudMessage.Success;
    }
  }
}
