using Erp.Data.Entities.Finance;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.Finance;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.Finance
{
  public class ExpenseCategoryRepository : GenericRepository<ExpenseCategory>, IExpenseCategoryRepository
  {
    private readonly DbSet<ExpenseCategory> _ExpenseCategorys;
    public ExpenseCategoryRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _ExpenseCategorys = dbContext.Set<ExpenseCategory>();

    }


    public async Task<string> AddExpenseCategoryAsync(ExpenseCategory ExpenseCategory)
    {
      var result = await _ExpenseCategorys.AddAsync(ExpenseCategory);

      if (result == null)
      {
        return "Cant Add";
      }
      else
      {
        return MessageCenter.CrudMessage.Success;
      }
    }

    public async Task<ExpenseCategory?> GetExpenseCategoryByIdAsync(int id)
    {
      return await _ExpenseCategorys.FindAsync(id);

    }

    public async Task<List<ExpenseCategory>> GetExpenseCategorysListAsync()
    {
      return await _ExpenseCategorys.ToListAsync();
    }

    public async Task<string> UpdateExpenseCategoryAsync(ExpenseCategory request)
    {
      var result = _ExpenseCategorys.Update(request);

      return MessageCenter.CrudMessage.Success;
    }
  }
}
