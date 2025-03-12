using AutoMapper;
using Erp.Core.Features.StockTaking.Queries.Models;
using Erp.Core.Features.StockTaking.Queries.Results;
using Erp.Service.Abstracts.InventoryModule;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.StockTaking.Queries.Handlers
{
  public class StockTakingQueryHandler : ResponseHandler,
    IRequestHandler<GetStockTakingByIdQuery, Response<GetStockTakingByIdResult>>, IRequestHandler<GetStockTakingListQuery, Response<List<GetStockTakingListResult>>>
  {
    #region Fields
    private readonly IStockTakingService _StockTakingService;
    private readonly IMapper _mapper;
    #endregion
    public StockTakingQueryHandler(IStockTakingService StockTakingService, IMapper mapper)
    {
      _mapper = mapper;
      _StockTakingService = StockTakingService;
    }

    public async Task<Response<GetStockTakingByIdResult>> Handle(GetStockTakingByIdQuery request, CancellationToken cancellationToken)
    {
      var StockTaking = await _StockTakingService.GetStockTakingByIdAsync(request.Id);


      if (StockTaking == null)
      {
        return NotFound<GetStockTakingByIdResult>("StockTaking Not Found");
      }
      else
      {
        var StockTakingMapper = _mapper.Map<GetStockTakingByIdResult>(StockTaking);
        return Success(StockTakingMapper);
      }
    }

    public async Task<Response<List<GetStockTakingListResult>>> Handle(GetStockTakingListQuery request, CancellationToken cancellationToken)
    {
      var StockTakingList = await _StockTakingService.GetStockTakingsListAsync();

      var StockTakingListMapper = _mapper.Map<List<GetStockTakingListResult>>(StockTakingList);

      return Success(StockTakingListMapper);
    }
  }
}
