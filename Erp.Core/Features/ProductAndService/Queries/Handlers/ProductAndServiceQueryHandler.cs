using AutoMapper;
using Erp.Core.Features.ProductAndService.Queries.Models;
using Erp.Core.Features.ProductAndService.Queries.Results;
using Erp.Core.Wrappers;
using Erp.Data.Dto.ProductAndService;
using Erp.Data.Entities.InventoryModule;
using Erp.Service.Abstracts;
using Erp.Service.Abstracts.InventoryModule;
using MediatR;
using Name.Core.Bases;
using System.Linq.Expressions;
using E = Erp.Data.Entities.InventoryModule;
namespace Erp.Core.Features.ProductAndService.Queries.Handlers
{
  public class ProductAndServiceQueryHandler : ResponseHandler,
    IRequestHandler<GetServiceByIdQuery, Response<GetServiceByIdResult>>, IRequestHandler<GetServiceListQuery, Response<List<GetServiceByIdResult>>>,
    IRequestHandler<GetProductAndServicePaginatedListQuery, PaginatedResult<GetProductAndServicePaginatedListResult>>

  {
    #region Fields
    private readonly IProductService _productService;
    private readonly IProductAndServiceBaseService _ProductAndService;

    private readonly IMapper _mapper;
    #endregion
    public ProductAndServiceQueryHandler(IProductService productService,
      IMapper mapper,
      IProductAndServiceBaseService ProductAndService)
    {
      _mapper = mapper;
      _productService = productService;
      _ProductAndService = ProductAndService;
    }

    public async Task<Response<List<GetServiceByIdResult>>> Handle(GetServiceListQuery request, CancellationToken cancellationToken)
    {
      var ServiceList = await _ProductAndService.GetServiceListAsync();

      var ServiceListMapper = _mapper.Map<List<GetServiceByIdResult>>(ServiceList);

      return Success(ServiceListMapper);
    }

    public async Task<Response<GetServiceByIdResult>> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
    {
      var service = await _ProductAndService.GetServiceByIdAsync(request.Id);


      if (service == null)
      {
        return NotFound<GetServiceByIdResult>("service Not Found");
      }
      else
      {
        var serviceMapper = _mapper.Map<GetServiceByIdResult>(service);
        return Success(serviceMapper);
      }
    }

    public async Task<PaginatedResult<GetProductAndServicePaginatedListResult>> Handle(GetProductAndServicePaginatedListQuery request, CancellationToken cancellationToken)
    {
      Expression<Func<ProductAndServiceBase, GetProductAndServicePaginatedListResult>> expression = e => new GetProductAndServicePaginatedListResult(
        e.ProductId,
        e.Name,
        e.Description,
        e.InternalNotes,
        e.PurchasePrice,
        e.SellPrice,
        e.LowestSellingPrice,
        e.Status,
        e.ImagePath,
        e.categories.Select(c => c.CategoryId).ToList(),
        (e as E.Product) == null ? ProductOrService.Service : ProductOrService.Product,
        (e as E.Product).StockQuantity,
      (e as E.Product).MinAmountBeforNotefy,
      (e as E.Product).SupplierId);


      var queryable = _ProductAndService.GetProductAndServiceQueryable(request.Search, request.Status, request.CategoryId);

      var PaginatedList = await queryable.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);

      return PaginatedList;
    }
  }
}
