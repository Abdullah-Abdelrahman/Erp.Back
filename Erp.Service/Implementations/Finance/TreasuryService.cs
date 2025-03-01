using Erp.Data.Abstracts;
using Erp.Data.Dto.Treasury;
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
  public class TreasuryService : ITreasuryService
  {
    private readonly ITreasuryRepository _TreasuryRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IApplicationRoleRepository _applicationRoleRepository;
    private readonly IAccountService _accountService;

    private readonly IAccountRepository<SecondaryAccount> _SecondaryaccountRepository;




    public TreasuryService(ITreasuryRepository TreasuryRepository,
      IEmployeeRepository employeeRepository,
      IApplicationRoleRepository applicationRoleRepository,
      IAccountService accountService,
      IAccountRepository<SecondaryAccount> SecondaryaccountRepository)
    {
      _TreasuryRepository = TreasuryRepository;
      _applicationRoleRepository = applicationRoleRepository;
      _employeeRepository = employeeRepository;
      _accountService = accountService;
      _SecondaryaccountRepository = SecondaryaccountRepository;

    }
    public async Task<string> AddTreasury(AddTreasuryRequest TreasuryRequest)
    {
      var Treasury = new Treasury()
      {
        Name = TreasuryRequest.Name,
        Description = TreasuryRequest.Description == null ? string.Empty : TreasuryRequest.Description,
        IsActive = TreasuryRequest.IsActive,
        DepositPermission = TreasuryRequest.DepositPermission,
        WithdrawPermission = TreasuryRequest.WithdrawPermission
      };



      var transact = _TreasuryRepository.BeginTransaction();
      try
      {
        var newTreasury = await _TreasuryRepository.AddAsync(Treasury);

        switch (Treasury.DepositPermission)
        {
          case WhoHaveType.Employee:
            foreach (var item in TreasuryRequest.employeesWhoHaveDepositPermessionsIds)
            {
              newTreasury.employeesWhoHaveDepositPermessions.
                Add(await _employeeRepository.GetByIdAsync(item));
              //get the employee

            }
            break;
          case WhoHaveType.Job_Role:
            foreach (var item in TreasuryRequest.RolesWhoHaveDepositPermessionsIds)
            {
              newTreasury.RolesWhoHaveDepositPermessions.
                Add(await _applicationRoleRepository.GetByIdAsync(item));
              //get the Role

            }
            break;
          case WhoHaveType.Every_One:
            foreach (var item in await _employeeRepository.GetTableAsTracking().ToListAsync())
            {
              newTreasury.employeesWhoHaveDepositPermessions.Add(item);
            }
            //get all employee
            break;
          default:
            break;
        }
        switch (Treasury.WithdrawPermission)
        {
          case WhoHaveType.Employee:
            foreach (var item in TreasuryRequest.employeesWhoHaveWithdrawPermessionsIds)
            {
              newTreasury.employeesWhoHaveWithdrawPermessions.
                Add(await _employeeRepository.GetByIdAsync(item));
              //get the employee

            }
            break;
          case WhoHaveType.Job_Role:
            foreach (var item in TreasuryRequest.RolesWhoHaveWithdrawPermessionsIds)
            {
              newTreasury.RolesWhoHaveWithdrawPermessions.
                Add(await _applicationRoleRepository.GetByIdAsync(item));
              //get the Role

            }
            break;
          case WhoHaveType.Every_One:
            foreach (var item in await _employeeRepository.GetTableAsTracking().ToListAsync())
            {
              newTreasury.employeesWhoHaveWithdrawPermessions.Add(item);
            }
            //get all employee
            break;
          default:
            break;
        }

        await _TreasuryRepository.UpdateAsync(newTreasury);

        var acc = new SecondaryAccount()
        {
          AccountName = newTreasury.Name,
          Type = AccountType.debtor,
          Balance = 0,
          ParentAccountID = (await _SecondaryaccountRepository.GetTableNoTracking().Where(a => a.AccountName == "Treasury").SingleOrDefaultAsync())?.AccountID,
          IsActive = newTreasury.IsActive == true ? true : false,
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

    public async Task<string> DeleteAsync(Treasury Treasury)
    {

      var transact = _TreasuryRepository.BeginTransaction();
      try
      {
        await _TreasuryRepository.DeleteAsync(Treasury);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<GetTreasuryByIdDto> GetTreasuryByIdAsync(int id)
    {
      var Treasury = _TreasuryRepository.GetTableNoTracking().
        Where(x => x.Id == id).
        Include(x => x.employeesWhoHaveDepositPermessions).
        Include(x => x.employeesWhoHaveWithdrawPermessions).
        Include(x => x.RolesWhoHaveDepositPermessions).
        Include(x => x.RolesWhoHaveWithdrawPermessions).
        SingleOrDefault();

      if (Treasury == null)
      {
        return new GetTreasuryByIdDto();
      }
      var dto = new GetTreasuryByIdDto()
      {
        Id = Treasury.Id,
        Name = Treasury.Name,
        Description = Treasury.Description,
        IsActive = Treasury.IsActive,
        DepositPermission = Treasury.DepositPermission,
        WithdrawPermission = Treasury.WithdrawPermission,
        employeesWhoHaveDepositPermessions = Treasury.employeesWhoHaveDepositPermessions,
        employeesWhoHaveWithdrawPermessions = Treasury.employeesWhoHaveWithdrawPermessions,
        RolesWhoHaveDepositPermessions = Treasury.RolesWhoHaveDepositPermessions,
        RolesWhoHaveWithdrawPermessions = Treasury.RolesWhoHaveWithdrawPermessions
      };



      return dto;
    }

    public async Task<List<GetTreasuryByIdDto>> GetTreasurysListAsync()
    {
      var Treasurys = _TreasuryRepository.GetTableNoTracking().ToList();

      var dtoList = new List<GetTreasuryByIdDto>();

      dtoList.AddRange(Treasurys.Select(x => new GetTreasuryByIdDto()
      {
        Id = x.Id,
        Name = x.Name,
        Description = x.Description,
        IsActive = x.IsActive,
        DepositPermission = x.DepositPermission,
        WithdrawPermission = x.WithdrawPermission

      }));

      return dtoList;
    }

    public async Task<string> UpdateAsync(UpdateTreasuryRequest TreasuryRequest)
    {
      var Treasury = await _TreasuryRepository.GetTableAsTracking().Where(x => x.Id == TreasuryRequest.Id).
        Include(x => x.employeesWhoHaveDepositPermessions).
        Include(x => x.employeesWhoHaveWithdrawPermessions).
        Include(x => x.RolesWhoHaveDepositPermessions).
        Include(x => x.RolesWhoHaveWithdrawPermessions).SingleOrDefaultAsync();


      Treasury.Name = TreasuryRequest.Name;
      Treasury.Description = TreasuryRequest.Description == null ? Treasury.Description : TreasuryRequest.Description;
      Treasury.IsActive = TreasuryRequest.IsActive;
      Treasury.DepositPermission = TreasuryRequest.DepositPermission;
      Treasury.WithdrawPermission = TreasuryRequest.WithdrawPermission;


      foreach (var item in Treasury.employeesWhoHaveWithdrawPermessions)
      {
        Treasury.employeesWhoHaveWithdrawPermessions.Remove(item);
      }
      foreach (var item in Treasury.RolesWhoHaveWithdrawPermessions.ToList())
      {
        Treasury.RolesWhoHaveWithdrawPermessions.Remove(item);
      }
      foreach (var item in Treasury.RolesWhoHaveDepositPermessions.ToList())
      {
        Treasury.RolesWhoHaveDepositPermessions.Remove(item);
      }

      var transact = _TreasuryRepository.BeginTransaction();
      try
      {
        await _TreasuryRepository.UpdateAsync(Treasury);

        //Write it after write the add logic
        switch (Treasury.DepositPermission)
        {
          case WhoHaveType.Employee:
            foreach (var item in TreasuryRequest.employeesWhoHaveDepositPermessionsIds)
            {
              Treasury.employeesWhoHaveDepositPermessions.
                Add(await _employeeRepository.GetByIdAsync(item));
              //get the employee

            }
            break;
          case WhoHaveType.Job_Role:
            foreach (var item in TreasuryRequest.RolesWhoHaveDepositPermessionsIds.ToList())
            {
              Treasury.RolesWhoHaveDepositPermessions.
                Add(await _applicationRoleRepository.GetByIdAsync(item));
              //get the Role

            }
            break;
          case WhoHaveType.Every_One:
            foreach (var item in await _employeeRepository.GetTableAsTracking().ToListAsync())
            {
              Treasury.employeesWhoHaveDepositPermessions.Add(item);
            }
            //get all employee
            break;
          default:
            break;
        }
        switch (Treasury.WithdrawPermission)
        {
          case WhoHaveType.Employee:
            foreach (var item in TreasuryRequest.employeesWhoHaveWithdrawPermessionsIds)
            {
              Treasury.employeesWhoHaveWithdrawPermessions.
                Add(await _employeeRepository.GetByIdAsync(item));
              //get the employee

            }
            break;
          case WhoHaveType.Job_Role:
            foreach (var item in TreasuryRequest.RolesWhoHaveWithdrawPermessionsIds)
            {
              Treasury.RolesWhoHaveWithdrawPermessions.
                Add(await _applicationRoleRepository.GetByIdAsync(item));
              //get the Role

            }
            break;
          case WhoHaveType.Every_One:
            foreach (var item in await _employeeRepository.GetTableAsTracking().ToListAsync())
            {
              Treasury.employeesWhoHaveWithdrawPermessions.Add(item);
            }
            //get all employee
            break;
          default:
            break;
        }

        await _TreasuryRepository.UpdateAsync(Treasury);


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
      var Treasury = _TreasuryRepository.GetTableNoTracking().Where(x => x.Id == id).SingleOrDefault();

      if (Treasury == null)
      {
        return MessageCenter.CrudMessage.DoesNotExist;
      }
      var transact = _TreasuryRepository.BeginTransaction();
      try
      {
        await _TreasuryRepository.DeleteAsync(Treasury);

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
