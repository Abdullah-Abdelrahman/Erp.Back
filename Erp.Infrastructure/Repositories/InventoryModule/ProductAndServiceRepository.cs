using Erp.Data.Entities.InventoryModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.InventoryModule;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.InventoryModule
{
  public class ProductAndServiceRepository<TPAndS> : GenericRepository<TPAndS>, IProductAndServiceRepository<TPAndS> where TPAndS : ProductAndServiceBase
  {
    private readonly DbSet<TPAndS> _Items;

    public ProductAndServiceRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _Items = dbContext.Set<TPAndS>();
    }

    public async Task<string> AddProductAndServiceAsync(TPAndS Item)
    {
      await _Items.AddAsync(Item);
      await _dbContext.SaveChangesAsync(); // Ensure changes are saved

      return MessageCenter.CrudMessage.Success;
    }

    public async Task<TPAndS?> GetProductAndServiceByIdAsync(int id)
    {
      return await _Items.FindAsync(id);
    }

    public async Task<List<T>> GetProductsAndServicesByTypeAsync<T>() where T : ProductAndServiceBase
    {
      return await _Items.OfType<T>().ToListAsync();
    }

    public async Task<List<TPAndS>> GetProductsAndServicesListAsync()
    {
      return await _Items.ToListAsync();
    }

    public async Task<string> UpdateProductAndServiceAsync(TPAndS Item)
    {
      _Items.Update(Item);
      await _dbContext.SaveChangesAsync();

      return MessageCenter.CrudMessage.Success;
    }
  }
}
