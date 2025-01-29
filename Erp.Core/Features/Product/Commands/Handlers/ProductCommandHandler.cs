using AutoMapper;
using Erp.Core.Features.Product.Commands.Models;
using Erp.Data.MetaData;
using Erp.Service.Abstracts;
using MediatR;
using Name.Core.Bases;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Features.Product.Commands.Handlers
{

  public class ProductCommandHandler : ResponseHandler,
    IRequestHandler<AddProductCommand, Response<string>>,
     IRequestHandler<EditProductCommand, Response<string>>,
     IRequestHandler<DeleteProductCommand, Response<string>>
  {
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductCommandHandler(IProductService productService, IMapper mapper)
    {
      _productService = productService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
      var productMapper = _mapper.Map<Entitis.InventoryModule.Product>(request);
      var result = await _productService.AddProductAsync(productMapper, request.ImageFile, request.WebRootPath);

      if (result == MessageCenter.CrudMessage.Exist)
      {
        return UnprocessableEntity<string>("Name Exist Befor");
      }
      else if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Added successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(EditProductCommand request, CancellationToken cancellationToken)
    {
      var productMapper = _mapper.Map<Entitis.InventoryModule.Product>(request);
      var result = await _productService.UpdateAsync(productMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
      var productInDB = await _productService.GetProductByIdAsync(request.Id);


      if (productInDB == null)
      {
        return NotFound<string>("There is no product with this id");
      }
      else
      {

        var result = await _productService.DeleteAsync(productInDB);

        if (result == MessageCenter.CrudMessage.Success)
        {
          return Deleted<string>();
        }
        else
        {
          return BadRequest<string>("Somthing bad happened");
        }



      }
    }
  }
}

