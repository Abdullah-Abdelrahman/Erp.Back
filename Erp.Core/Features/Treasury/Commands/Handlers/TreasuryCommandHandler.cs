using AutoMapper;
using Erp.Core.Features.Treasury.Commands.Models;
using Erp.Data.Dto.Treasury;
using Erp.Data.MetaData;
using Erp.Service.Abstracts.Finance;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Treasury.Commands.Handlers
{
  public class TreasuryCommandHandler : ResponseHandler,
    IRequestHandler<AddTreasuryCommand, Response<string>>,
    IRequestHandler<EditTreasuryCommand, Response<string>>,
  IRequestHandler<DeleteTreasuryCommand, Response<string>>


  {

    private readonly ITreasuryService _TreasuryService;
    private readonly IMapper _mapper;

    public TreasuryCommandHandler(ITreasuryService TreasuryService, IMapper mapper)
    {
      _TreasuryService = TreasuryService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddTreasuryCommand request, CancellationToken cancellationToken)
    {
      var AddTreasuryRequestMapper = _mapper.Map<AddTreasuryRequest>(request);
      var result = await _TreasuryService.AddTreasury(AddTreasuryRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Added successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(EditTreasuryCommand request, CancellationToken cancellationToken)
    {

      var EditTreasuryRequestMapper = _mapper.Map<UpdateTreasuryRequest>(request);
      var result = await _TreasuryService.UpdateAsync(EditTreasuryRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened" + result);
      }


    }

    public async Task<Response<string>> Handle(DeleteTreasuryCommand request, CancellationToken cancellationToken)
    {


      var result = await _TreasuryService.DeleteByIdAsync(request.Id);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Deleted<string>();
      }
      else
      {
        return BadRequest<string>(result);
      }




    }



  }
}
