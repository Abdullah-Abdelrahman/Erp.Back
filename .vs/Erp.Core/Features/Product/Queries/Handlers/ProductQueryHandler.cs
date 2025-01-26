using AutoMapper;
using Erp.Core.Features.Product.Queries.Models;
using Erp.Core.Features.Product.Queries.Results;
using Erp.Service.Abstracts;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Product.Queries.Handlers
{
  public class ProductQueryHandler : ResponseHandler, IRequestHandler<GetProductByIdQuery, Response<GetProductByIdResult>>, IRequestHandler<GetProductListQuery, Response<List<GetProductByIdResult>>>
  {
    #region Fields
    private readonly IProductService _productService;

    private readonly IMapper _mapper;
    #endregion
    public ProductQueryHandler(IProductService productService, IMapper mapper)
    {
      _mapper = mapper;
      _productService = productService;
    }

    public async Task<Response<GetProductByIdResult>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
      var product = await _productService.GetProductByIdAsync(request.Id);


      if (product == null)
      {
        return NotFound<GetProductByIdResult>("product Not Found");
      }
      else
      {
        var productMapper = _mapper.Map<GetProductByIdResult>(product);
        return Success(productMapper);
      }
    }

    public async Task<Response<List<GetProductByIdResult>>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
      var ProductList = await _productService.GetProductsListAsync();

      var ProductListMapper = _mapper.Map<List<GetProductByIdResult>>(ProductList);

      return Success(ProductListMapper);
    }
  }
}
