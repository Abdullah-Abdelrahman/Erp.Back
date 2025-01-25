using Erp.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace Erp.Service.Abstracts
{
  public interface IProductService
  {

    public Task<List<Product>> GetProductsListAsync();

    public Task<Product> GetProductByIdAsync(int id);

    public Task<string> AddProductAsync(Product Product, IFormFile? ImageFile, string? webRootPath);

    public Task<string> UpdateAsync(Product Product);

    public Task<string> DeleteAsync(Product Product);
  }
}
