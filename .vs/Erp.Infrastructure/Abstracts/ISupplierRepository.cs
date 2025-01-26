using Erp.Data.Entities;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts
{
  public interface ISupplierRepository : IGenericRepository<Supplier>
  {
    public Task<string> AddSupplierAsync(Supplier Supplier);

    public Task<Supplier> GetSupplierByIdAsync(int id);

    public Task<List<Supplier>> GetSuppliersListAsync();

    public Task<string> UpdateSupplierAsync(Supplier request);
  }
}
