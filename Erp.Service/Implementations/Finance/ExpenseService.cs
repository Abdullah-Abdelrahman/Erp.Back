using Erp.Data.Dto.Expense;
using Erp.Data.Entities;
using Erp.Data.Entities.AccountsModule;
using Erp.Data.Entities.Finance;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.AccountsModule;
using Erp.Infrastructure.Abstracts.Finance;
using Erp.Service.Abstracts.Finance;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations.Finance
{
  public class ExpenseService : IExpenseService
  {
    private readonly IExpenseRepository _ExpenseRepository;
    private readonly IExpenseCategoryRepository _expenseCategoryRepository;

    private readonly IAccountRepository<SecondaryAccount> _accountRepository;

    private readonly ITreasuryRepository _treasuryRepository;

    private readonly IMultiAccExpenseItemRepository _multiAccExpenseItemRepository;


    public ExpenseService(IExpenseRepository ExpenseRepository
      , IAccountRepository<SecondaryAccount> accountRepository,
IExpenseCategoryRepository expenseCategoryRepository,
ITreasuryRepository treasuryRepository,
IMultiAccExpenseItemRepository multiAccExpenseItemRepository)
    {
      _ExpenseRepository = ExpenseRepository;
      _accountRepository = accountRepository;
      _expenseCategoryRepository = expenseCategoryRepository;
      _treasuryRepository = treasuryRepository;
      _multiAccExpenseItemRepository = multiAccExpenseItemRepository;
    }
    // ملحوظة: في حال لم يتم اختيار الحساب الفرعي؛ سيقوم النظام بتوجيه المصروف إلى حساب “مصروفات أخرى”.

    private async Task<int> GetMainTreasuryId()
    {
      var tras = (await _treasuryRepository.
         GetTableNoTracking().FirstOrDefaultAsync());

      if (tras == null)
      {
        return 0;
      }
      return tras.Id;
    }
    private async Task<int> GetDefaultSubAccountId()
    {
      var Acc = (await _accountRepository.GetTableNoTracking().
        Where(a => a.AccountName == "Other Expenses").SingleOrDefaultAsync());
      if (Acc == null)
      {
        return 0;
      }
      return Acc.AccountID;
    }
    public async Task<string> AddExpense(AddExpenseRequest ExpenseRequest)
    {

      var Tid = await GetMainTreasuryId();

      var SubAccId = await GetDefaultSubAccountId();


      var Expense = new Expense()
      {
        CodeNumber = ExpenseRequest.CodeNumber,
        Amount = ExpenseRequest.Amount,
        Currency = ExpenseRequest.Currency,
        Date = ExpenseRequest.Date is null ? DateTime.Now : (DateTime)ExpenseRequest.Date,
        Description = ExpenseRequest.Description == null ? string.Empty : ExpenseRequest.Description,
        SupplierId = ExpenseRequest.SupplierId,
        TreasuryId = ExpenseRequest.TreasuryId == 0 ? Tid
        : ExpenseRequest.TreasuryId,
        Isfrequent = ExpenseRequest.Isfrequent,
        IsMultiAccount = ExpenseRequest.IsMultiAccount,
        WithCostCenter = ExpenseRequest.WithCostCenter,
        SubAccountId = ExpenseRequest.SubAccountId == null ? SubAccId : (int)ExpenseRequest.SubAccountId

      };





      var transact = _ExpenseRepository.BeginTransaction();
      try
      {
        var newExpense = await _ExpenseRepository.AddAsync(Expense);

        foreach (var item in ExpenseRequest.CategoriesIds)
        {
          var category = await _expenseCategoryRepository.GetByIdAsync(item);
          if (category == null) throw new Exception($"ExpenseCategory with ID {item} not found.");
          newExpense.expenseCategories.Add(category);
        }
        decimal total = 0;

        if (newExpense.WithCostCenter)
        {
          foreach (var item in ExpenseRequest.expenseCostCenterDtos)
          {
            var expenseCostCenterItem = new ExpenseCostCenter()
            {
              ExpenseId = newExpense.Id,
              CostCenterId = item.CostCenterId,
              Amount = item.Amount,
              Percentage = item.Percentage

            };
            total += expenseCostCenterItem.Amount;
            newExpense.ExpenseCostCenters.Add(expenseCostCenterItem);
          }
        }

        if (newExpense.IsMultiAccount)
        {
          total = 0;
          foreach (var item in ExpenseRequest.multiAccExpenseItems)
          {
            var expenseCostCenterItem = new MultiAccExpenseItem()
            {
              ExpenseId = newExpense.Id,
              SecondaryAccountId = newExpense.SubAccountId == null ? SubAccId : newExpense.SubAccountId,
              CostCenterId = item.CostCenterId,
              Amount = item.Amount,
              Tax = item.Tax

            };
            total += expenseCostCenterItem.Amount;
            await _multiAccExpenseItemRepository.AddAsync(expenseCostCenterItem);
          }

        }

        newExpense.Amount = total;

        await _ExpenseRepository.UpdateAsync(newExpense);
        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch (Exception ex)
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied + ex.Message;
      }

    }

    public async Task<string> DeleteAsync(Expense Expense)
    {

      var transact = _ExpenseRepository.BeginTransaction();
      try
      {
        await _ExpenseRepository.DeleteAsync(Expense);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<GetExpenseByIdDto> GetExpenseByIdAsync(int id)
    {
      var Expense = await _ExpenseRepository.GetTableNoTracking().Where(x => x.Id == id)
        .Include(x => x.Supplier)
        .Include(x => x.expenseCategories)
        .Include(x => x.SubAccount)
        .Include(x => x.Treasury)
        .Include(x => x.ExpenseCostCenters)
        .Include(x => x.multiAccExpenseItems).SingleOrDefaultAsync();
      if (Expense == null)
      {
        return new GetExpenseByIdDto();
      }

      var dto = new GetExpenseByIdDto()
      {
        Id = Expense.Id,
        CodeNumber = Expense.CodeNumber,
        Amount = Expense.Amount,
        Currency = Expense.Currency,
        Date = Expense.Date,
        Description = Expense.Description,
        CategoriesIds = Expense.expenseCategories.Select(x => x.Id).ToList(),
        SupplierId = Expense.SupplierId,
        SubAccountId = Expense.SubAccountId,
        TreasuryId = Expense.TreasuryId,
        Isfrequent = Expense.Isfrequent,
        IsMultiAccount = Expense.IsMultiAccount,
        WithCostCenter = Expense.WithCostCenter
      };


      if (dto.WithCostCenter)
      {
        foreach (var item in Expense.ExpenseCostCenters)
        {
          var expenseCostCenterItem = new ExpenseCostCenterGetDto()
          {
            ExpenseId = item.ExpenseId,
            CostCenterId = item.CostCenterId,
            Amount = item.Amount,
            Percentage = item.Percentage

          };
          dto.expenseCostCenterDtos.Add(expenseCostCenterItem);
        }
      }

      if (dto.IsMultiAccount)
      {
        foreach (var item in Expense.multiAccExpenseItems)
        {
          var multiAccExpenseItem = new MultiAccExpenseItemGetDto()
          {
            Id = item.Id,
            SecondaryAccountId = item.SecondaryAccountId,
            CostCenterId = item.CostCenterId,
            Amount = item.Amount,
            Tax = item.Tax

          };
          dto.multiAccExpenseItems.Add(multiAccExpenseItem);
        }
      }


      return dto;
    }

    public async Task<List<GetExpenseByIdDto>> GetExpensesListAsync()
    {
      var Expenses = await _ExpenseRepository.GetTableNoTracking()
        .Include(x => x.Supplier).ToListAsync();

      var dtoList = new List<GetExpenseByIdDto>();

      dtoList.AddRange(Expenses.Select(x => new GetExpenseByIdDto()
      {
        Id = x.Id,
        CodeNumber = x.CodeNumber,
        Amount = x.Amount,
        Currency = x.Currency,
        Date = x.Date,
        Description = x.Description,
        CategoriesIds = x.expenseCategories.Select(x => x.Id).ToList(),
        SupplierId = x.SupplierId,
        SubAccountId = x.SubAccountId,
        TreasuryId = x.TreasuryId,
        Isfrequent = x.Isfrequent,
        IsMultiAccount = x.IsMultiAccount,
        WithCostCenter = x.WithCostCenter

      }));

      return dtoList;
    }

    public async Task<string> UpdateAsync(UpdateExpenseRequest ExpenseRequest)
    {


      var Expense = await _ExpenseRepository.GetExpenseByIdAsync(ExpenseRequest.Id);
      if (Expense == null)
      {
        return MessageCenter.CrudMessage.DoesNotExist;
      }

      Expense.CodeNumber = ExpenseRequest.CodeNumber;
      Expense.Amount = ExpenseRequest.Amount;
      Expense.Currency = ExpenseRequest.Currency;
      Expense.Date = ExpenseRequest.Date is null ? DateTime.Now : (DateTime)ExpenseRequest.Date;
      Expense.Description = ExpenseRequest.Description == null ? string.Empty : ExpenseRequest.Description;
      Expense.SupplierId = ExpenseRequest.SupplierId;
      Expense.TreasuryId = ExpenseRequest.TreasuryId;
      Expense.Isfrequent = ExpenseRequest.Isfrequent;
      Expense.IsMultiAccount = ExpenseRequest.IsMultiAccount;
      Expense.WithCostCenter = ExpenseRequest.WithCostCenter;





      var transact = _ExpenseRepository.BeginTransaction();
      try
      {
        await _ExpenseRepository.UpdateAsync(Expense);


        foreach (var item in Expense.expenseCategories.ToList())
        {
          if (!ExpenseRequest.CategoriesIds.Contains(item.Id))
          {
            Expense.expenseCategories.Remove(item);
          }

        }

        foreach (var item in ExpenseRequest.CategoriesIds)
        {
          if (!Expense.expenseCategories.Any(x => x.Id == item))
          {
            var category = await _expenseCategoryRepository.GetByIdAsync(item);
            if (category == null) throw new Exception($"ExpenseCategory with ID {item} not found.");
            Expense.expenseCategories.Add(category);
          }



        }
        decimal total = 0;

        if (Expense.WithCostCenter)
        {

          foreach (var item in Expense.ExpenseCostCenters.ToList())
          {
            Expense.ExpenseCostCenters.Remove(item);
          }
          foreach (var item in ExpenseRequest.expenseCostCenterDtos)
          {
            var expenseCostCenterItem = new ExpenseCostCenter()
            {
              ExpenseId = Expense.Id,
              CostCenterId = item.CostCenterId,
              Amount = item.Amount,
              Percentage = item.Percentage

            };
            total += expenseCostCenterItem.Amount;
            Expense.ExpenseCostCenters.Add(expenseCostCenterItem);
          }
        }

        if (Expense.IsMultiAccount)
        {
          total = 0;
          await _multiAccExpenseItemRepository.GetTableAsTracking().Where(x => x.ExpenseId == Expense.Id).ExecuteDeleteAsync();
          foreach (var item in ExpenseRequest.multiAccExpenseItems)
          {
            var expenseCostCenterItem = new MultiAccExpenseItem()
            {
              SecondaryAccountId = Expense.SubAccountId,
              CostCenterId = item.CostCenterId,
              Amount = item.Amount,
              Tax = item.Tax

            };
            total += expenseCostCenterItem.Amount;
            Expense.multiAccExpenseItems.Add(expenseCostCenterItem);
          }

        }
        Expense.Amount = total;


        await _ExpenseRepository.UpdateAsync(Expense);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch (Exception ex)
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied + ex.Message;
      }
    }



    public async Task<string> DeleteByIdAsync(int id)
    {
      var Expense = _ExpenseRepository.GetTableNoTracking().Where(x => x.Id == id).SingleOrDefault();

      if (Expense == null)
      {
        return MessageCenter.CrudMessage.DoesNotExist;
      }
      var transact = _ExpenseRepository.BeginTransaction();
      try
      {
        await _ExpenseRepository.DeleteAsync(Expense);

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
