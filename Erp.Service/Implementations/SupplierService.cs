using Erp.Data.Entities.AccountsModule;
using Erp.Data.Entities.PurchasesModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts;
using Erp.Infrastructure.Abstracts.AccountsModule;
using Erp.Service.Abstracts;
using Erp.Service.Abstracts.AccountsModule;
using Microsoft.EntityFrameworkCore;
using Name.Service.Abstracts;

namespace Erp.Service.Implementations
{
  public class SupplierService : ISupplierService
  {


    private readonly ISupplierRepository _SupplierRepository;

    private readonly IFileService _FileService;
    private readonly IAccountRepository<SecondaryAccount> _SecondaryAccountRepository;
    private readonly IAccountRepository<PrimaryAccount> _PrimaryAccountRepository;
    private readonly IAccountService _accountService;
    public SupplierService(
      ISupplierRepository SupplierRepository,
      IFileService fileService,
      IAccountRepository<SecondaryAccount> SecondaryAccountRepository,
        IAccountRepository<PrimaryAccount> PrimaryAccountRepository,
        IAccountService accountService)
    {
      _SupplierRepository = SupplierRepository;
      _FileService = fileService;
      _SecondaryAccountRepository = SecondaryAccountRepository;
      _PrimaryAccountRepository = PrimaryAccountRepository;
      _accountService = accountService;
    }

    public async Task<string> AddSupplierAsync(Supplier Supplier)
    {

      var transact = _SupplierRepository.BeginTransaction();
      try
      {

        var acc = new SecondaryAccount()
        {
          AccountName = Supplier.SupplierName,
          Type = AccountType.creditor,
          Balance = 0,
          ParentAccountID = (await _PrimaryAccountRepository.GetTableNoTracking().Where(a => a.AccountName == "Suppliers").SingleOrDefaultAsync())?.AccountID,
          IsActive = true,
          CreatedDate = DateTime.UtcNow,
        };
        await _accountService.AddAccountAsync(acc);
        Supplier.AccountId = acc.AccountID;
        var supplier = await _SupplierRepository.AddAsync(Supplier);


        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch (Exception ex)
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied + ex.Message;
      }


    }

    public async Task<string> DeleteAsync(Supplier Supplier)
    {
      try
      {
        await _SupplierRepository.DeleteAsync(Supplier);
        return MessageCenter.CrudMessage.Success;
      }
      catch (Exception ex)
      {
        return "There is a problem in deleteing the Supplier : " + ex.Message;
      }

    }

    public async Task<Supplier> GetSupplierByIdAsync(int id)
    {
      var Supplier = _SupplierRepository.GetTableNoTracking().Where(x => x.SupplierId == id).SingleOrDefault();

      return Supplier;
    }

    public async Task<List<Supplier>> GetSuppliersListAsync()
    {
      var Suppliers = await _SupplierRepository.GetSuppliersListAsync();

      return Suppliers;
    }

    public async Task<string> UpdateAsync(Supplier Supplier)
    {
      var sup = await _SupplierRepository.GetSupplierByIdAsync(Supplier.SupplierId);

      var transact = _SupplierRepository.BeginTransaction();
      try
      {
        Supplier.AccountId = sup.AccountId;
        await _SupplierRepository.UpdateAsync(Supplier);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch (Exception ex)
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied + ex.Message;
      }
    }
  }
}
