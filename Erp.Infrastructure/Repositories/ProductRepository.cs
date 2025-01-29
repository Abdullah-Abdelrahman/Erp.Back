using Erp.Data.Entities.InventoryModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories
{
  public class ProductRepository : GenericRepository<Product>, IProductRepository
  {
    private readonly DbSet<Product> _products;
    public ProductRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _products = dbContext.Set<Product>();

    }


    public async Task<string> AddProductAsync(Product product)
    {
      var result = await _products.AddAsync(product);

      if (result == null)
      {
        return "Cant Add";
      }
      else
      {
        return MessageCenter.CrudMessage.Success;
      }
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
      return await _products.FindAsync(id);

    }

    public async Task<List<Product>> GetProductsListAsync()
    {
      return await _products.ToListAsync();
    }

    public async Task<string> UpdateProductAsync(Product request)
    {
      var result = _products.Update(request);

      return MessageCenter.CrudMessage.Success;
    }
  }
}
