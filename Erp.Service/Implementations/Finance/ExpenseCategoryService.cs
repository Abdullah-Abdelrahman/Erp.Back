using Erp.Data.Entities.Finance;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.Finance;
using Erp.Service.Abstracts.Finance;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations.Finance
{
  public class ExpenseCategoryService : IExpenseCategoryService
  {
    private readonly IExpenseCategoryRepository _ExpenseCategoryRepository;


    public ExpenseCategoryService(IExpenseCategoryRepository ExpenseCategoryRepository)
    {
      _ExpenseCategoryRepository = ExpenseCategoryRepository;
    }
    public async Task<string> AddExpenseCategoryAsync(ExpenseCategory ExpenseCategory)
    {

      var newExpenseCategory = await _ExpenseCategoryRepository.AddAsync(ExpenseCategory);
      if (newExpenseCategory != null)
      {
        return MessageCenter.CrudMessage.Success;
      }
      else
      {
        return "Somthing bad happend :";
      }
    }

    public async Task<string> DeleteAsync(ExpenseCategory ExpenseCategory)
    {
      try
      {
        await _ExpenseCategoryRepository.DeleteAsync(ExpenseCategory);
        return MessageCenter.CrudMessage.Success;
      }
      catch (Exception ex)
      {
        return "There is a problem in deleteing the ExpenseCategory : " + ex.Message;
      }

    }

    public async Task<ExpenseCategory> GetExpenseCategoryByIdAsync(int id)
    {
      var ExpenseCategory = await _ExpenseCategoryRepository.GetTableNoTracking().Where(x => x.Id == id).SingleOrDefaultAsync();

      return ExpenseCategory;
    }

    public async Task<List<ExpenseCategory>> GetExpenseCategorysListAsync()
    {
      var ExpenseCategorys = await _ExpenseCategoryRepository.GetTableNoTracking().ToListAsync();

      return ExpenseCategorys;
    }

    public async Task<string> UpdateAsync(ExpenseCategory ExpenseCategory)
    {
      var transact = _ExpenseCategoryRepository.BeginTransaction();
      try
      {
        await _ExpenseCategoryRepository.UpdateAsync(ExpenseCategory);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }
  }
}
