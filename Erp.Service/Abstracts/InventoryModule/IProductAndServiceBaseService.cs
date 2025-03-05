using Erp.Data.Dto.ProductAndService;
using Erp.Data.Entities.InventoryModule;
using Microsoft.AspNetCore.Http;
using E = Erp.Data.Entities.InventoryModule;
namespace Erp.Service.Abstracts.InventoryModule
{
  public interface IProductAndServiceBaseService
  {
    Task<string> AddServiceAsync(AddServiceRequest Item, IFormFile? ImageFile, string? webRootPath);


    Task<Product?> GetProductByIdAsync(int id);


    Task<E.Service?> GetServiceByIdAsync(int id);

    Task<List<Product>> GetProductListAsync();

    Task<List<E.Service>> GetServiceListAsync();


    Task<string> UpdateServiceAsync(UpdateServiceRequest Item);


    Task<string> DeleteProductOrServiceAsync(int id);

    Task<List<T>> GetProductsOrServicesByTypeAsync<T>() where T : ProductAndServiceBase;

    Task<string> GetProductOrServiceTypeByIdAsync(int ItemId);

    public IQueryable<ProductAndServiceBase> GetProductAndServiceQueryable();
    public IQueryable<ProductAndServiceBase> GetProductAndServiceQueryable(string? Search, ProductStatus? status, int? category);
  }
}
