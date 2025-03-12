using AutoMapper;
using Erp.Core.Features.PriceList.Queries.Models;
using Erp.Core.Features.PriceList.Queries.Results;
using Erp.Service.Abstracts.InventoryModule;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.PriceList.Queries.Handlers
{
  public class PriceListQueryHandler : ResponseHandler,
    IRequestHandler<GetPriceListByIdQuery, Response<GetPriceListByIdResult>>, IRequestHandler<GetPriceListListQuery, Response<List<GetPriceListListResult>>>
  {
    #region Fields
    private readonly IPriceListService _PriceListService;
    private readonly IMapper _mapper;
    #endregion
    public PriceListQueryHandler(IPriceListService PriceListService, IMapper mapper)
    {
      _mapper = mapper;
      _PriceListService = PriceListService;
    }

    public async Task<Response<GetPriceListByIdResult>> Handle(GetPriceListByIdQuery request, CancellationToken cancellationToken)
    {
      var PriceList = await _PriceListService.GetPriceListByIdAsync(request.Id);


      if (PriceList == null)
      {
        return NotFound<GetPriceListByIdResult>("PriceList Not Found");
      }
      else
      {
        var PriceListMapper = _mapper.Map<GetPriceListByIdResult>(PriceList);
        return Success(PriceListMapper);
      }
    }

    public async Task<Response<List<GetPriceListListResult>>> Handle(GetPriceListListQuery request, CancellationToken cancellationToken)
    {
      var PriceListList = await _PriceListService.GetPriceListsListAsync();

      var PriceListListMapper = _mapper.Map<List<GetPriceListListResult>>(PriceListList);

      return Success(PriceListListMapper);
    }
  }
}
