using Erp.Data.Abstracts;
using Erp.Data.Dto.BankAccount;
using Erp.Data.Entities.AccountsModule;
using Erp.Data.Entities.Finance;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.AccountsModule;
using Erp.Infrastructure.Abstracts.Finance;
using Erp.Infrastructure.Abstracts.HumanResources.Staff;
using Erp.Infrastructure.Abstracts.MainModule;
using Erp.Service.Abstracts.AccountsModule;
using Erp.Service.Abstracts.Finance;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations.Finance
{
  public class BankAccountService : IBankAccountService
  {
    private readonly IBankAccountRepository _BankAccountRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IApplicationRoleRepository _applicationRoleRepository;
    private readonly IAccountService _accountService;

    private readonly IAccountRepository<SecondaryAccount> _SecondaryaccountRepository;

    private readonly IAccountRepository<PrimaryAccount> _PrimaryaccountRepository;



    public BankAccountService(IBankAccountRepository BankAccountRepository,
      IEmployeeRepository employeeRepository,
      IApplicationRoleRepository applicationRoleRepository,
      IAccountService accountService,
      IAccountRepository<SecondaryAccount> SecondaryaccountRepository,
      IAccountRepository<PrimaryAccount> primaryaccountRepository)
    {
      _BankAccountRepository = BankAccountRepository;
      _applicationRoleRepository = applicationRoleRepository;
      _employeeRepository = employeeRepository;
      _accountService = accountService;
      _SecondaryaccountRepository = SecondaryaccountRepository;
      _PrimaryaccountRepository = primaryaccountRepository;
    }
    public async Task<string> AddBankAccount(AddBankAccountRequest BankAccountRequest)
    {
      var BankAccount = new BankAccount()
      {
        AccountHolderName = BankAccountRequest.AccountHolderName,
        BankName = BankAccountRequest.BankName,
        AccountNumber = BankAccountRequest.AccountNumber,
        Currency = BankAccountRequest.Currency,
        Status = BankAccountRequest.Status,
        DepositPermission = BankAccountRequest.DepositPermission,
        WithdrawPermission = BankAccountRequest.WithdrawPermission
      };



      var transact = _BankAccountRepository.BeginTransaction();
      try
      {
        var newBankAccount = await _BankAccountRepository.AddAsync(BankAccount);

        switch (BankAccount.DepositPermission)
        {
          case WhoHaveType.Employee:
            foreach (var item in BankAccountRequest.employeesWhoHaveDepositPermessionsIds)
            {
              newBankAccount.employeesWhoHaveDepositPermessions.
                Add(await _employeeRepository.GetByIdAsync(item));
              //get the employee

            }
            break;
          case WhoHaveType.Job_Role:
            foreach (var item in BankAccountRequest.RolesWhoHaveDepositPermessionsIds)
            {
              newBankAccount.RolesWhoHaveDepositPermessions.
                Add(await _applicationRoleRepository.GetByIdAsync(item));
              //get the Role

            }
            break;
          case WhoHaveType.Every_One:
            foreach (var item in await _employeeRepository.GetTableAsTracking().ToListAsync())
            {
              newBankAccount.employeesWhoHaveDepositPermessions.Add(item);
            }
            //get all employee
            break;
          default:
            break;
        }
        switch (BankAccount.WithdrawPermission)
        {
          case WhoHaveType.Employee:
            foreach (var item in BankAccountRequest.employeesWhoHaveWithdrawPermessionsIds)
            {
              newBankAccount.employeesWhoHaveWithdrawPermessions.
                Add(await _employeeRepository.GetByIdAsync(item));
              //get the employee

            }
            break;
          case WhoHaveType.Job_Role:
            foreach (var item in BankAccountRequest.RolesWhoHaveWithdrawPermessionsIds)
            {
              newBankAccount.RolesWhoHaveWithdrawPermessions.
                Add(await _applicationRoleRepository.GetByIdAsync(item));
              //get the Role

            }
            break;
          case WhoHaveType.Every_One:
            foreach (var item in await _employeeRepository.GetTableAsTracking().ToListAsync())
            {
              newBankAccount.employeesWhoHaveWithdrawPermessions.Add(item);
            }
            //get all employee
            break;
          default:
            break;
        }

        await _BankAccountRepository.UpdateAsync(newBankAccount);

        var acc = new SecondaryAccount()
        {
          AccountName = newBankAccount.BankName,
          Type = AccountType.debtor,
          Balance = 0,
          ParentAccountID = (await _PrimaryaccountRepository.GetTableNoTracking().Where(a => a.AccountName == "Bank").SingleOrDefaultAsync())?.AccountID,
          IsActive = newBankAccount.Status == AccountStatus.ACTIVE ? true : false,
          CreatedDate = DateTime.UtcNow,
        };
        await _accountService.AddAccountAsync(acc);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch (Exception ex)
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied + ex.Message;
      }

    }

    public async Task<string> DeleteAsync(BankAccount BankAccount)
    {

      var transact = _BankAccountRepository.BeginTransaction();
      try
      {
        await _BankAccountRepository.DeleteAsync(BankAccount);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<GetBankAccountByIdDto> GetBankAccountByIdAsync(int id)
    {
      var BankAccount = _BankAccountRepository.GetTableNoTracking().
        Where(x => x.BankAccountID == id).
        Include(x => x.employeesWhoHaveDepositPermessions).
        Include(x => x.employeesWhoHaveWithdrawPermessions).
        Include(x => x.RolesWhoHaveDepositPermessions).
        Include(x => x.RolesWhoHaveWithdrawPermessions).
        SingleOrDefault();

      if (BankAccount == null)
      {
        return new GetBankAccountByIdDto();
      }
      var dto = new GetBankAccountByIdDto()
      {
        BankAccountID = BankAccount.BankAccountID,
        AccountHolderName = BankAccount.AccountHolderName,
        BankName = BankAccount.BankName,
        AccountNumber = BankAccount.AccountNumber,
        Currency = BankAccount.Currency,
        Status = BankAccount.Status,
        DepositPermission = BankAccount.DepositPermission,
        WithdrawPermission = BankAccount.WithdrawPermission,
        employeesWhoHaveDepositPermessions = BankAccount.employeesWhoHaveDepositPermessions,
        employeesWhoHaveWithdrawPermessions = BankAccount.employeesWhoHaveWithdrawPermessions,
        RolesWhoHaveDepositPermessions = BankAccount.RolesWhoHaveDepositPermessions,
        RolesWhoHaveWithdrawPermessions = BankAccount.RolesWhoHaveWithdrawPermessions
      };



      return dto;
    }

    public async Task<List<GetBankAccountByIdDto>> GetBankAccountsListAsync()
    {
      var BankAccounts = _BankAccountRepository.GetTableNoTracking().ToList();

      var dtoList = new List<GetBankAccountByIdDto>();

      dtoList.AddRange(BankAccounts.Select(x => new GetBankAccountByIdDto()
      {
        BankAccountID = x.BankAccountID,
        AccountHolderName = x.AccountHolderName,
        BankName = x.BankName,
        AccountNumber = x.AccountNumber,
        Currency = x.Currency,
        Status = x.Status,
        DepositPermission = x.DepositPermission,
        WithdrawPermission = x.WithdrawPermission

      }));

      return dtoList;
    }

    public async Task<string> UpdateAsync(UpdateBankAccountRequest BankAccountRequest)
    {
      var bankAccount = await _BankAccountRepository.GetTableAsTracking().Where(x => x.BankAccountID == BankAccountRequest.BankAccountID).
        Include(x => x.employeesWhoHaveDepositPermessions).
        Include(x => x.employeesWhoHaveWithdrawPermessions).
        Include(x => x.RolesWhoHaveDepositPermessions).
        Include(x => x.RolesWhoHaveWithdrawPermessions).SingleOrDefaultAsync();

      bankAccount.BankAccountID = BankAccountRequest.BankAccountID;
      bankAccount.AccountHolderName = BankAccountRequest.AccountHolderName;
      bankAccount.BankName = BankAccountRequest.BankName;
      bankAccount.AccountNumber = BankAccountRequest.AccountNumber;
      bankAccount.Currency = BankAccountRequest.Currency;
      bankAccount.Status = BankAccountRequest.Status;
      bankAccount.DepositPermission = BankAccountRequest.DepositPermission;
      bankAccount.WithdrawPermission = BankAccountRequest.WithdrawPermission;


      foreach (var item in bankAccount.employeesWhoHaveWithdrawPermessions)
      {
        bankAccount.employeesWhoHaveWithdrawPermessions.Remove(item);
      }
      foreach (var item in bankAccount.RolesWhoHaveWithdrawPermessions.ToList())
      {
        bankAccount.RolesWhoHaveWithdrawPermessions.Remove(item);
      }
      foreach (var item in bankAccount.RolesWhoHaveDepositPermessions.ToList())
      {
        bankAccount.RolesWhoHaveDepositPermessions.Remove(item);
      }

      var transact = _BankAccountRepository.BeginTransaction();
      try
      {
        await _BankAccountRepository.UpdateAsync(bankAccount);

        //Write it after write the add logic
        switch (bankAccount.DepositPermission)
        {
          case WhoHaveType.Employee:
            foreach (var item in BankAccountRequest.employeesWhoHaveDepositPermessionsIds)
            {
              bankAccount.employeesWhoHaveDepositPermessions.
                Add(await _employeeRepository.GetByIdAsync(item));
              //get the employee

            }
            break;
          case WhoHaveType.Job_Role:
            foreach (var item in BankAccountRequest.RolesWhoHaveDepositPermessionsIds.ToList())
            {
              bankAccount.RolesWhoHaveDepositPermessions.
                Add(await _applicationRoleRepository.GetByIdAsync(item));
              //get the Role

            }
            break;
          case WhoHaveType.Every_One:
            foreach (var item in await _employeeRepository.GetTableAsTracking().ToListAsync())
            {
              bankAccount.employeesWhoHaveDepositPermessions.Add(item);
            }
            //get all employee
            break;
          default:
            break;
        }
        switch (bankAccount.WithdrawPermission)
        {
          case WhoHaveType.Employee:
            foreach (var item in BankAccountRequest.employeesWhoHaveWithdrawPermessionsIds)
            {
              bankAccount.employeesWhoHaveWithdrawPermessions.
                Add(await _employeeRepository.GetByIdAsync(item));
              //get the employee

            }
            break;
          case WhoHaveType.Job_Role:
            foreach (var item in BankAccountRequest.RolesWhoHaveWithdrawPermessionsIds)
            {
              bankAccount.RolesWhoHaveWithdrawPermessions.
                Add(await _applicationRoleRepository.GetByIdAsync(item));
              //get the Role

            }
            break;
          case WhoHaveType.Every_One:
            foreach (var item in await _employeeRepository.GetTableAsTracking().ToListAsync())
            {
              bankAccount.employeesWhoHaveWithdrawPermessions.Add(item);
            }
            //get all employee
            break;
          default:
            break;
        }

        await _BankAccountRepository.UpdateAsync(bankAccount);


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
      var BankAccount = _BankAccountRepository.GetTableNoTracking().Where(x => x.BankAccountID == id).SingleOrDefault();

      if (BankAccount == null)
      {
        return MessageCenter.CrudMessage.DoesNotExist;
      }
      var transact = _BankAccountRepository.BeginTransaction();
      try
      {
        await _BankAccountRepository.DeleteAsync(BankAccount);

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
