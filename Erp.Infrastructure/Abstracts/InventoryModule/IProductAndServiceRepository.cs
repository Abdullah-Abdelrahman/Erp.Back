using Erp.Data.Entities.InventoryModule;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.InventoryModule
{
  public interface IProductAndServiceRepository<TPAndS> : IGenericRepository<TPAndS> where TPAndS : ProductAndServiceBase
  {
    Task<string> AddProductAndServiceAsync(TPAndS Item);
    Task<TPAndS?> GetProductAndServiceByIdAsync(int id);
    Task<List<TPAndS>> GetProductsAndServicesListAsync();
    Task<string> UpdateProductAndServiceAsync(TPAndS Item);
    Task<List<T>> GetProductsAndServicesByTypeAsync<T>() where T : ProductAndServiceBase;
  }

}
