using AutoMapper;
using Erp.Core.Features.PurchaseReturn.Commands.Models;
using Erp.Data.Dto.PurchaseReturn;
using Erp.Data.MetaData;
using Erp.Service.Abstracts;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.PurchaseReturn.Commands.Handlers
{
  public class PurchaseReturnCommandHandler : ResponseHandler,
    IRequestHandler<AddPurchaseReturnCommand, Response<string>>,
    IRequestHandler<EditPurchaseReturnCommand, Response<string>>,
  IRequestHandler<DeletePurchaseReturnCommand, Response<string>>


  {

    private readonly IPurchaseReturnService _PurchaseReturnService;
    private readonly IMapper _mapper;

    public PurchaseReturnCommandHandler(IPurchaseReturnService PurchaseReturnService, IMapper mapper)
    {
      _PurchaseReturnService = PurchaseReturnService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddPurchaseReturnCommand request, CancellationToken cancellationToken)
    {
      var AddPurchaseReturnRequestMapper = _mapper.Map<AddPurchaseReturnRequest>(request);
      var result = await _PurchaseReturnService.AddPurchaseReturn(AddPurchaseReturnRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Added successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(EditPurchaseReturnCommand request, CancellationToken cancellationToken)
    {

      var EditPurchaseReturnRequestMapper = _mapper.Map<UpdatePurchaseReturnRequest>(request);
      var result = await _PurchaseReturnService.UpdateAsync(EditPurchaseReturnRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }


    }

    public async Task<Response<string>> Handle(DeletePurchaseReturnCommand request, CancellationToken cancellationToken)
    {


      var result = await _PurchaseReturnService.DeleteByIdAsync(request.Id);

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
