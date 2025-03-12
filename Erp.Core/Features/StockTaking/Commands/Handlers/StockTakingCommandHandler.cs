using AutoMapper;
using Erp.Core.Features.StockTaking.Commands.Models;
using Erp.Data.MetaData;
using Erp.Service.Abstracts.InventoryModule;
using MediatR;
using Name.Core.Bases;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Features.StockTaking.Commands.Handlers
{
  public class StockTakingCommandHandler : ResponseHandler,
    IRequestHandler<AddStockTakingCommand, Response<string>>,
    IRequestHandler<EditStockTakingCommand, Response<string>>,
    IRequestHandler<DeleteStockTakingCommand, Response<string>>,
    IRequestHandler<AddStockTakingItemCommand, Response<string>>,
    IRequestHandler<SettlementStockTakingCommand, Response<string>>




  {
    private readonly IStockTakingService _StockTakingService;
    private readonly IMapper _mapper;

    public StockTakingCommandHandler(IStockTakingService StockTakingService, IMapper mapper)
    {
      _StockTakingService = StockTakingService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddStockTakingCommand request, CancellationToken cancellationToken)
    {
      var StockTakingMapper = _mapper.Map<Entitis.InventoryModule.StockTaking>(request);
      var result = await _StockTakingService.AddStockTakingAsync(StockTakingMapper);

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

    public async Task<Response<string>> Handle(EditStockTakingCommand request, CancellationToken cancellationToken)
    {
      var StockTakingMapper = _mapper.Map<Entitis.InventoryModule.StockTaking>(request);
      var result = await _StockTakingService.UpdateAsync(StockTakingMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(DeleteStockTakingCommand request, CancellationToken cancellationToken)
    {
      var StockTaking = await _StockTakingService.GetStockTakingByIdAsync(request.StockTakingId);
      var result = await _StockTakingService.DeleteAsync(StockTaking);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Deleted successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(AddStockTakingItemCommand request, CancellationToken cancellationToken)
    {
      var StockTakingMapper = _mapper.Map<Entitis.InventoryModule.StockTakingItem>(request);
      var result = await _StockTakingService.AddStockTakingItemAsync(StockTakingMapper);
      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened :" + result);
      }

    }

    public Task<Response<string>> Handle(SettlementStockTakingCommand request, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }
  }
}
