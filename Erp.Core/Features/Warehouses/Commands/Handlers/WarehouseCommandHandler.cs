using AutoMapper;
using Erp.Core.Features.Warehouses.Commands.Models;
using Erp.Data.MetaData;
using Erp.Service.Abstracts;
using MediatR;
using Name.Core.Bases;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Features.Warehouses.Commands.Handlers
{
  public class WarehouseCommandHandler : ResponseHandler,
    IRequestHandler<AddWarehouseCommand, Response<string>>,
     IRequestHandler<EditWarehouseCommand, Response<string>>,
     IRequestHandler<DeleteWarehouseCommand, Response<string>>
  {
    private readonly IWarehouseService _warehouseService;
    private readonly IMapper _mapper;

    public WarehouseCommandHandler(IWarehouseService warehouseService, IMapper mapper)
    {
      _warehouseService = warehouseService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddWarehouseCommand request, CancellationToken cancellationToken)
    {
      var warehouseMapper = _mapper.Map<Entitis.Warehouse>(request);
      var result = await _warehouseService.AddWarehouse(warehouseMapper);

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

    public async Task<Response<string>> Handle(DeleteWarehouseCommand request, CancellationToken cancellationToken)
    {
      var productInDB = await _warehouseService.GetWarehouseByIdAsync(request.Id);


      if (productInDB == null)
      {
        return NotFound<string>("There is no warehouse with this id");
      }
      else
      {

        var result = await _warehouseService.DeleteAsync(productInDB);

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

    public async Task<Response<string>> Handle(EditWarehouseCommand request, CancellationToken cancellationToken)
    {
      var warehouseMapper = _mapper.Map<Entitis.Warehouse>(request);
      var result = await _warehouseService.UpdateAsync(warehouseMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }
  }
}
