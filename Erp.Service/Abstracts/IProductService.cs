using Erp.Data.Dto.Product;
using Erp.Data.Entities.InventoryModule;
using Microsoft.AspNetCore.Http;

namespace Erp.Service.Abstracts
{
  public interface IProductService
  {

    public Task<List<Product>> GetProductsListAsync();

    public Task<Product> GetProductByIdAsync(int id);

    public Task<string> AddProductAsync(AddProductRequest Product, IFormFile? ImageFile, string? webRootPath);

    public Task<string> UpdateAsync(UpdateProductRequest Product);

    public Task<string> DeleteAsync(Product Product);
  }
}
