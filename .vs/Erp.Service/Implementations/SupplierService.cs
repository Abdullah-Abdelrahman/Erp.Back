using Erp.Data.Entities;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts;
using Erp.Service.Abstracts;
using Name.Service.Abstracts;

namespace Erp.Service.Implementations
{
  public class SupplierService : ISupplierService
  {


    private readonly ISupplierRepository _SupplierRepository;

    private readonly IFileService _FileService;
    public SupplierService(ISupplierRepository SupplierRepository, IFileService fileService)
    {
      _SupplierRepository = SupplierRepository;
      _FileService = fileService;
    }

    public async Task<string> AddSupplierAsync(Supplier Supplier)
    {
      var newCourse = await _SupplierRepository.AddAsync(Supplier);
      if (newCourse != null)
      {
        return MessageCenter.CrudMessage.Success;
      }
      else
      {
        return "Somthing bad happend :";
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
      var transact = _SupplierRepository.BeginTransaction();
      try
      {
        await _SupplierRepository.UpdateAsync(Supplier);

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
