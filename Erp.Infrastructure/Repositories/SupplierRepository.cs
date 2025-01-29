using Erp.Data.Entities.PurchasesModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories
{
  public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
  {
    private readonly DbSet<Supplier> _Suppliers;
    public SupplierRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _Suppliers = dbContext.Set<Supplier>();

    }


    public async Task<string> AddSupplierAsync(Supplier Supplier)
    {
      var result = await _Suppliers.AddAsync(Supplier);

      if (result == null)
      {
        return "Cant Add";
      }
      else
      {
        return MessageCenter.CrudMessage.Success;
      }
    }

    public async Task<Supplier> GetSupplierByIdAsync(int id)
    {
      return await _Suppliers.FindAsync(id);

    }

    public async Task<List<Supplier>> GetSuppliersListAsync()
    {
      return await _Suppliers.ToListAsync();
    }

    public async Task<string> UpdateSupplierAsync(Supplier request)
    {
      var result = _Suppliers.Update(request);

      return MessageCenter.CrudMessage.Success;
    }
  }
}
