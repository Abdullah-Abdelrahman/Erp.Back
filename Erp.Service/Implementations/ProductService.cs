using Erp.Data.Dto.Product;
using Erp.Data.Entities.InventoryModule;
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

    private readonly ICategoryRepository _categoryRepository;
    public ProductService(IProductRepository productRepository, IFileService fileService, ICategoryRepository categoryRepository)
    {
      _productRepository = productRepository;
      _FileService = fileService;
      _categoryRepository = categoryRepository;
    }

    public async Task UpdateProductQuantatiyAsync(int ProId, int Qua)
    {
      var pro = await _productRepository.GetProductByIdAsync(ProId);
      pro.StockQuantity += Qua;
      await _productRepository.UpdateAsync(pro);
      return;
    }

    public async Task<string> AddProductAsync(AddProductRequest ProductReq, IFormFile? ImageFile, string? webRootPath)
    {
      var product = new Product()
      {
        Name = ProductReq.ProductName,
        Description = ProductReq.Description is null ? "" : ProductReq.Description,
        InternalNotes = ProductReq.InternalNotes is null ? "" : ProductReq.InternalNotes,
        PurchasePrice = ProductReq.PurchasePrice,
        SellPrice = ProductReq.SellPrice,
        LowestSellingPrice = ProductReq.LowestSellingPrice == null ? ProductReq.SellPrice : (decimal)ProductReq.LowestSellingPrice,
        StockQuantity = ProductReq.StockQuantity == null ? 0 : (int)ProductReq.StockQuantity,
        MinAmountBeforNotefy = ProductReq.MinAmountBeforNotefy == null ? 0 : (int)ProductReq.MinAmountBeforNotefy,
        SupplierId = ProductReq.SupplierId

      };

      foreach (var id in ProductReq.categoriesIds)
      {
        product.categories.Add(await _categoryRepository.GetByIdAsync(id));
      }

      product.ImagePath = (await _FileService.UploadFile(ImageFile, webRootPath));
      var newProduct = await _productRepository.AddAsync(product);


      if (newProduct != null)
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
      var product = _productRepository.GetTableNoTracking().Where(x => x.ProductId == id).Include(p => p.categories).SingleOrDefault();
      if (product != null)
      {
        product.ImageFile = await _FileService.GetFileAsync(product.ImagePath);

      }
      return product;
    }

    public async Task<List<Product>> GetProductsListAsync()
    {
      var Products = await _productRepository.GetTableNoTracking().Include(p => p.categories).ToListAsync();
      foreach (var product in Products)
      {
        product.ImageFile = await _FileService.GetFileAsync(product.ImagePath);
      }
      return Products;
    }

    public async Task<string> UpdateAsync(UpdateProductRequest ProductReq)
    {



      var product = await _productRepository.GetProductByIdAsync(ProductReq.ProductId);

      if (product == null)
      {
        return MessageCenter.CrudMessage.DoesNotExist;
      }
      product.Name = ProductReq.ProductName;
      product.Description = ProductReq.Description is null ? "" : ProductReq.Description;
      product.InternalNotes = ProductReq.InternalNotes;
      product.PurchasePrice = ProductReq.PurchasePrice;
      product.SellPrice = ProductReq.SellPrice;
      product.LowestSellingPrice = ProductReq.LowestSellingPrice;
      product.StockQuantity = ProductReq.StockQuantity;
      product.MinAmountBeforNotefy = ProductReq.MinAmountBeforNotefy;
      product.SupplierId = ProductReq.SupplierId;
      // product.Status= ProductReq.Status;

      product.StockQuantity = ProductReq.StockQuantity;
      // product.TrackInventory = ProductReq.;


      foreach (var cat in product.categories.ToList())
      {
        product.categories.Remove(cat);
      }

      foreach (var id in ProductReq.categoriesIds)
      {
        product.categories.Add(await _categoryRepository.GetByIdAsync(id));
      }


      var transact = _productRepository.BeginTransaction();
      try
      {
        await _productRepository.UpdateAsync(product);

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
