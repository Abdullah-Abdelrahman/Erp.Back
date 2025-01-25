using Erp.Data.Entities;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts;
using Erp.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Name.Service.Abstracts;

namespace Erp.Service.Implementations
{
  public class ProductService : IProductService
  {


    private readonly IProductRepository _productRepository;

    private readonly IFileService _FileService;
    public ProductService(IProductRepository productRepository, IFileService fileService)
    {
      _productRepository = productRepository;
      _FileService = fileService;
    }

    public async Task<string> AddProductAsync(Product Product, IFormFile? ImageFile, string? webRootPath)
    {
      Product.ImagePath = (await _FileService.UploadFile(ImageFile, webRootPath));
      var newCourse = await _productRepository.AddAsync(Product);
      if (newCourse != null)
      {
        return MessageCenter.CrudMessage.Success;
      }
      else
      {
        return "Somthing bad happend :";
      }
    }

    public async Task<string> DeleteAsync(Product Product)
    {
      try
      {
        await _productRepository.DeleteAsync(Product);
        return MessageCenter.CrudMessage.Success;
      }
      catch (Exception ex)
      {
        return "There is a problem in deleteing the product : " + ex.Message;
      }

    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
      var product = _productRepository.GetTableNoTracking().Where(x => x.ProductId == id).Include(p => p.Category).SingleOrDefault();
      if (product != null)
      {
        product.ImageFile = await _FileService.GetFileAsync(product.ImagePath);

      }
      return product;
    }

    public async Task<List<Product>> GetProductsListAsync()
    {
      var Products = await _productRepository.GetProductsListAsync();
      foreach (var product in Products)
      {
        product.ImageFile = await _FileService.GetFileAsync(product.ImagePath);
      }
      return Products;
    }

    public async Task<string> UpdateAsync(Product Product)
    {
      var transact = _productRepository.BeginTransaction();
      try
      {
        await _productRepository.UpdateAsync(Product);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }
  }
}
