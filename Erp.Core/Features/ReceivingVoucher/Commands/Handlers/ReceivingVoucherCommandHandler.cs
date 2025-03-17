using AutoMapper;
using Erp.Core.Features.ReceivingVoucher.Commands.Models;
using Erp.Data.Dto.ReceivingVoucher;
using Erp.Data.MetaData;
using Erp.Service.Abstracts;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.ReceivingVoucher.Commands.Handlers
{
  public class ReceivingVoucherCommandHandler : ResponseHandler,
    IRequestHandler<AddReceivingVoucherCommand, Response<string>>,
    IRequestHandler<EditReceivingVoucherCommand, Response<string>>,
  IRequestHandler<DeleteReceivingVoucherCommand, Response<string>>,
  IRequestHandler<RejectReceivingVoucherCommand, Response<string>>,
  IRequestHandler<ConfirmReceivingVoucherCommand, Response<string>>
  {

    private readonly IReceivingVoucherService _receivingVoucherService;
    private readonly IMapper _mapper;

    public ReceivingVoucherCommandHandler(IReceivingVoucherService receivingVoucherService, IMapper mapper)
    {
      _receivingVoucherService = receivingVoucherService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddReceivingVoucherCommand request, CancellationToken cancellationToken)
    {
      var AddReceivingVoucherRequestMapper = _mapper.Map<AddReceivingVoucherRequest>(request);
      var result = await _receivingVoucherService.AddReceivingVoucherAsync(AddReceivingVoucherRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Added successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened :" + result);
      }
    }

    public async Task<Response<string>> Handle(EditReceivingVoucherCommand request, CancellationToken cancellationToken)
    {

      var EditReceivingVoucherRequestMapper = _mapper.Map<UpdateReceivingVoucherRequest>(request);
      var result = await _receivingVoucherService.UpdateAsync(EditReceivingVoucherRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }


    }

    public async Task<Response<string>> Handle(DeleteReceivingVoucherCommand request, CancellationToken cancellationToken)
    {


      var result = await _receivingVoucherService.DeleteByIdAsync(request.Id);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Deleted<string>();
      }
      else
      {
        return BadRequest<string>(result);
      }




    }

    public async Task<Response<string>> Handle(RejectReceivingVoucherCommand request, CancellationToken cancellationToken)
    {
      var result = await _receivingVoucherService.RejectReceivingVoucherAsync(request.Id);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Success<string>("Rejected");
      }
      else
      {
        return BadRequest<string>(result);
      }
    }

    public async Task<Response<string>> Handle(ConfirmReceivingVoucherCommand request, CancellationToken cancellationToken)
    {
      var result = await _receivingVoucherService.ConfirmReceivingVoucherAsync(request.Id);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Success<string>("Confirmed");
      }
      else
      {
        return BadRequest<string>(result);
      }
    }
  }
}
