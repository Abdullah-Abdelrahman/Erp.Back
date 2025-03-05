using AutoMapper;
using Erp.Core.Features.ProductAndService.Commands.Models;
using Erp.Data.Dto.ProductAndService;
using Erp.Data.MetaData;
using Erp.Service.Abstracts.InventoryModule;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.ProductAndService.Commands.Handlers
{

  public class ProductAndServiceCommandHandler : ResponseHandler,
    IRequestHandler<AddServiceCommand, Response<string>>,
     IRequestHandler<EditServiceCommand, Response<string>>,
     IRequestHandler<DeleteServiceCommand, Response<string>>
  {
    private readonly IProductAndServiceBaseService _productAndServiceService;
    private readonly IMapper _mapper;

    public ProductAndServiceCommandHandler(IProductAndServiceBaseService productAndServiceService, IMapper mapper)
    {
      _productAndServiceService = productAndServiceService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddServiceCommand request, CancellationToken cancellationToken)
    {
      var ServiceMapper = _mapper.Map<AddServiceRequest>(request);
      var result = await _productAndServiceService.AddServiceAsync(ServiceMapper, request.ImageFile, request.WebRootPath);

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

    public async Task<Response<string>> Handle(EditServiceCommand request, CancellationToken cancellationToken)
    {
      var ServiceMapper = _mapper.Map<UpdateServiceRequest>(request);
      var result = await _productAndServiceService.UpdateServiceAsync(ServiceMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
      var ServiceInDB = await _productAndServiceService.GetServiceByIdAsync(request.Id);


      if (ServiceInDB == null)
      {
        return NotFound<string>("There is no Service with this id");
      }
      else
      {

        var result = await _productAndServiceService.DeleteProductOrServiceAsync(ServiceInDB.ProductId);

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

