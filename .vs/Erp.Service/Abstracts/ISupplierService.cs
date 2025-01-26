using Erp.Data.Entities;

namespace Erp.Service.Abstracts
{
  public interface ISupplierService
  {
    public Task<List<Supplier>> GetSuppliersListAsync();

    public Task<Supplier> GetSupplierByIdAsync(int id);

    public Task<string> AddSupplierAsync(Supplier Supplier);

    public Task<string> UpdateAsync(Supplier Supplier);

    public Task<string> DeleteAsync(Supplier Supplier);
  }
}
