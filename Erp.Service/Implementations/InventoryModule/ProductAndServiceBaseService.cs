using Erp.Data.Dto.ProductAndService;
using Erp.Data.Entities.InventoryModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts;
using Erp.Infrastructure.Abstracts.InventoryModule;
using Erp.Service.Abstracts;
using Erp.Service.Abstracts.InventoryModule;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Name.Service.Abstracts;
using E = Erp.Data.Entities.InventoryModule;
namespace Erp.Service.Implementations.InventoryModule
{
  public class ProductAndServiceBaseService : IProductAndServiceBaseService
  {

    private readonly IProductAndServiceRepository<ProductAndServiceBase> _productAndServiceRepository;
    private readonly IProductAndServiceRepository<E.Service> _ServiceRepository;
    private readonly IProductService _productService;
    private readonly IFileService _FileService;

    private readonly ICategoryRepository _categoryRepository;
    public ProductAndServiceBaseService(
      IProductAndServiceRepository<ProductAndServiceBase> productAndServiceRepository,
      IProductAndServiceRepository<E.Service> ServiceRepository,
      IProductService productService,
      IFileService fileService,
      ICategoryRepository categoryRepository)
    {
      _productAndServiceRepository = productAndServiceRepository;
      _ServiceRepository = ServiceRepository;
      _productService = productService;
      _categoryRepository = categoryRepository;
      _FileService = fileService;
    }

    public async Task<string> AddServiceAsync(AddServiceRequest Item, IFormFile? ImageFile, string? webRootPath)
    {
      var service = new E.Service()
      {
        Name = Item.ServiceName,
        Description = Item.Description is null ? "" : Item.Description,
        InternalNotes = Item.InternalNotes is null ? "" : Item.InternalNotes,
        PurchasePrice = Item.PurchasePrice,
        SellPrice = Item.SellPrice,
        LowestSellingPrice = Item.LowestSellingPrice == null ? Item.SellPrice : (decimal)Item.LowestSellingPrice,

      };

      foreach (var id in Item.categoriesIds)
      {
        service.categories.Add(await _categoryRepository.GetByIdAsync(id));
      }

      service.ImagePath = (await _FileService.UploadFile(ImageFile, webRootPath));
      var newProduct = await _productAndServiceRepository.AddAsync(service);


      if (newProduct != null)
      {
        return MessageCenter.CrudMessage.Success;
      }
      else
      {
        return "Somthing bad happend :";
      }
    }

    public async Task<string> DeleteProductOrServiceAsync(int id)
    {
      try
      {
        var account = await _productAndServiceRepository.GetProductAndServiceByIdAsync(id);
        if (account != null)
        {

          await _productAndServiceRepository.DeleteAsync(account);
          return MessageCenter.CrudMessage.Success;
        }
        return MessageCenter.CrudMessage.DoesNotExist;
      }
      catch
      {
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public IQueryable<ProductAndServiceBase> GetProductAndServiceQueryable()
    {

      return _productAndServiceRepository.GetTableNoTracking().Include(x => x.categories).AsQueryable();
    }

    public IQueryable<ProductAndServiceBase> GetProductAndServiceQueryable(string? Search, ProductStatus? status, int? category)
    {
      var queryable = _productAndServiceRepository.GetTableNoTracking().Include(x => x.categories).AsQueryable();
      if (Search != null)
      {
        queryable = queryable.Where(x => x.Name.StartsWith(Search) || x.ProductId.ToString().StartsWith(Search));
      }

      if (status != null)
      {
        queryable = queryable.Where(x => x.Status == status);
      }
      if (category != null)
      {
        queryable = queryable.Where(x => x.categories.Any(c => c.CategoryId == category));
      }

      return queryable;
    }

    public Task<Product?> GetProductByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<List<Product>> GetProductListAsync()
    {
      throw new NotImplementedException();
    }

    public async Task<string> GetProductOrServiceTypeByIdAsync(int ItemId)
    {
      var Product = await _productService.GetProductByIdAsync(ItemId);
      if (Product != null) return "Product";

      var Service = await _ServiceRepository.GetByIdAsync(ItemId);
      if (Service != null) return "Service";

      return "Unknown";
    }

    public async Task<List<T>> GetProductsOrServicesByTypeAsync<T>() where T : ProductAndServiceBase
    {
      try
      {
        return await _productAndServiceRepository.GetProductsAndServicesByTypeAsync<T>();
      }
      catch
      {
        return new List<T>();
      }
    }

    public async Task<Data.Entities.InventoryModule.Service?> GetServiceByIdAsync(int id)
    {
      try
      {
        var result = await _ServiceRepository.GetTableNoTracking().Where(x => x.ProductId == id).Include(x => x.categories).SingleOrDefaultAsync();


        return result;
      }
      catch
      {
        return null;
      }
    }

    public async Task<List<Data.Entities.InventoryModule.Service>> GetServiceListAsync()
    {
      var result = await _ServiceRepository.GetTableNoTracking().ToListAsync();

      return result;
    }

    public async Task<string> UpdateServiceAsync(UpdateServiceRequest Item)
    {

      E.Service service = (E.Service)await _productAndServiceRepository.GetByIdAsync(Item.ServiceId);

      if (service == null)
      {
        return MessageCenter.CrudMessage.DoesNotExist;
      }
      service.Name = Item.ServiceName;
      service.Description = Item.Description is null ? "" : Item.Description;
      service.InternalNotes = Item.InternalNotes;
      service.PurchasePrice = Item.PurchasePrice;
      service.SellPrice = Item.SellPrice;
      service.LowestSellingPrice = Item.LowestSellingPrice == null ? Item.SellPrice : (decimal)Item.LowestSellingPrice;
      //service.Status = Item.;

      foreach (var cat in service.categories.ToList())
      {
        service.categories.Remove(cat);
      }

      foreach (var id in Item.categoriesIds)
      {
        service.categories.Add(await _categoryRepository.GetByIdAsync(id));
      }
      var transact = _productAndServiceRepository.BeginTransaction();
      try
      {
        await _productAndServiceRepository.UpdateAsync(service);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;
      }
      catch (Exception ex)
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied + ex.Message;
      }
    }
  }
}
