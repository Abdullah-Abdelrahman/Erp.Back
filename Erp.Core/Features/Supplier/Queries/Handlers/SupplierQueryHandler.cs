using AutoMapper;
using Erp.Core.Features.Supplier.Queries.Models;
using Erp.Core.Features.Supplier.Queries.Results;
using Erp.Service.Abstracts;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Supplier.Queries.Handlers
{
  public class SupplierQueryHandler : ResponseHandler, IRequestHandler<GetSupplierByIdQuery, Response<GetSupplierByIdResult>>, IRequestHandler<GetSupplierListQuery, Response<List<GetSupplierByIdResult>>>
  {
    #region Fields
    private readonly ISupplierService _SupplierService;

    private readonly IMapper _mapper;
    #endregion
    public SupplierQueryHandler(ISupplierService SupplierService, IMapper mapper)
    {
      _mapper = mapper;
      _SupplierService = SupplierService;
    }

    public async Task<Response<GetSupplierByIdResult>> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
    {
      var Supplier = await _SupplierService.GetSupplierByIdAsync(request.Id);


      if (Supplier == null)
      {
        return NotFound<GetSupplierByIdResult>("Supplier Not Found");
      }
      else
      {
        var SupplierMapper = _mapper.Map<GetSupplierByIdResult>(Supplier);
        return Success(SupplierMapper);
      }
    }

    public async Task<Response<List<GetSupplierByIdResult>>> Handle(GetSupplierListQuery request, CancellationToken cancellationToken)
    {
      var SupplierList = await _SupplierService.GetSuppliersListAsync();

      var SupplierListMapper = _mapper.Map<List<GetSupplierByIdResult>>(SupplierList);

      return Success(SupplierListMapper);
    }
  }
}
