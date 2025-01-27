using AutoMapper;
using Erp.Core.Features.Warehouses.Queries.Models;
using Erp.Core.Features.Warehouses.Queries.Results;
using Erp.Service.Abstracts;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Warehouses.Queries.Handlers
{
  public class WarehouseQueryHandler : ResponseHandler, IRequestHandler<GetWarehouseByIdQuery, Response<GetWarehouseByIdResult>>, IRequestHandler<GetWarehouseListQuery, Response<List<GetWarehouseByIdResult>>>
  {
    #region Fields
    private readonly IWarehouseService _warehouseService;

    private readonly IMapper _mapper;
    #endregion
    public WarehouseQueryHandler(IWarehouseService warehouseService, IMapper mapper)
    {
      _mapper = mapper;
      _warehouseService = warehouseService;
    }

    public async Task<Response<GetWarehouseByIdResult>> Handle(GetWarehouseByIdQuery request, CancellationToken cancellationToken)
    {
      var warehouse = await _warehouseService.GetWarehouseByIdAsync(request.Id);


      if (warehouse == null)
      {
        return NotFound<GetWarehouseByIdResult>("warehouse Not Found");
      }
      else
      {
        var productMapper = _mapper.Map<GetWarehouseByIdResult>(warehouse);
        return Success(productMapper);
      }
    }

    public async Task<Response<List<GetWarehouseByIdResult>>> Handle(GetWarehouseListQuery request, CancellationToken cancellationToken)
    {
      var WarehouseList = await _warehouseService.GetWarehousesListAsync();

      var WarehouseListMapper = _mapper.Map<List<GetWarehouseByIdResult>>(WarehouseList);

      return Success(WarehouseListMapper);
    }
  }
}
