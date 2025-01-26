using Erp.Data.Entities;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts
{
  public interface IProductRepository : IGenericRepository<Product>
  {
    public Task<string> AddProductAsync(Product product);

    public Task<Product> GetProductByIdAsync(int id);

    public Task<List<Product>> GetProductsListAsync();

    public Task<string> UpdateProductAsync(Product request);
  }
}
