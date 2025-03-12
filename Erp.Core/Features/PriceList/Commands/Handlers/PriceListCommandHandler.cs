using AutoMapper;
using Erp.Core.Features.PriceList.Commands.Models;
using Erp.Data.MetaData;
using Erp.Service.Abstracts.InventoryModule;
using MediatR;
using Name.Core.Bases;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Features.PriceList.Commands.Handlers
{
  public class PriceListCommandHandler : ResponseHandler,
    IRequestHandler<AddPriceListCommand, Response<string>>,
    IRequestHandler<EditPriceListCommand, Response<string>>,
    IRequestHandler<DeletePriceListCommand, Response<string>>,
    IRequestHandler<AddPriceListItemCommand, Response<string>>



  {
    private readonly IPriceListService _PriceListService;
    private readonly IMapper _mapper;

    public PriceListCommandHandler(IPriceListService PriceListService, IMapper mapper)
    {
      _PriceListService = PriceListService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddPriceListCommand request, CancellationToken cancellationToken)
    {
      var PriceListMapper = _mapper.Map<Entitis.InventoryModule.PriceList>(request);
      var result = await _PriceListService.AddPriceListAsync(PriceListMapper);

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

    public async Task<Response<string>> Handle(EditPriceListCommand request, CancellationToken cancellationToken)
    {
      var PriceListMapper = _mapper.Map<Entitis.InventoryModule.PriceList>(request);
      var result = await _PriceListService.UpdateAsync(PriceListMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(DeletePriceListCommand request, CancellationToken cancellationToken)
    {
      var PriceList = await _PriceListService.GetPriceListByIdAsync(request.PriceListId);
      var result = await _PriceListService.DeleteAsync(PriceList);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Deleted successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(AddPriceListItemCommand request, CancellationToken cancellationToken)
    {
      var PriceListMapper = _mapper.Map<Entitis.InventoryModule.PriceListItem>(request);
      var result = await _PriceListService.AddPriceListItemAsync(PriceListMapper);
      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened :" + result);
      }

    }
  }
}
