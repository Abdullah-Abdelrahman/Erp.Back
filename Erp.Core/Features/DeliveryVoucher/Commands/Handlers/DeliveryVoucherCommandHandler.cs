using AutoMapper;
using Erp.Core.Features.DeliveryVoucher.Commands.Models;
using Erp.Data.Dto.DeliveryVoucher;
using Erp.Data.MetaData;
using Erp.Service.Abstracts;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.DeliveryVoucher.Commands.Handlers
{
  public class DeliveryVoucherCommandHandler : ResponseHandler,
    IRequestHandler<AddDeliveryVoucherCommand, Response<string>>,
    IRequestHandler<EditDeliveryVoucherCommand, Response<string>>,
  IRequestHandler<DeleteDeliveryVoucherCommand, Response<string>>,
  IRequestHandler<ConfirmDeliveryVoucherCommand, Response<string>>,
  IRequestHandler<RejectDeliveryVoucherCommand, Response<string>>




  {

    private readonly IDeliveryVoucherService _DeliveryVoucherService;
    private readonly IMapper _mapper;

    public DeliveryVoucherCommandHandler(IDeliveryVoucherService DeliveryVoucherService, IMapper mapper)
    {
      _DeliveryVoucherService = DeliveryVoucherService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddDeliveryVoucherCommand request, CancellationToken cancellationToken)
    {
      var AddDeliveryVoucherRequestMapper = _mapper.Map<AddDeliveryVoucherRequest>(request);
      var result = await _DeliveryVoucherService.AddDeliveryVoucherAsync(AddDeliveryVoucherRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Added successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(EditDeliveryVoucherCommand request, CancellationToken cancellationToken)
    {

      var EditDeliveryVoucherRequestMapper = _mapper.Map<UpdateDeliveryVoucherRequest>(request);
      var result = await _DeliveryVoucherService.UpdateAsync(EditDeliveryVoucherRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }


    }

    public async Task<Response<string>> Handle(DeleteDeliveryVoucherCommand request, CancellationToken cancellationToken)
    {


      var result = await _DeliveryVoucherService.DeleteByIdAsync(request.Id);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Deleted<string>();
      }
      else
      {
        return BadRequest<string>(result);
      }




    }

    public async Task<Response<string>> Handle(ConfirmDeliveryVoucherCommand request, CancellationToken cancellationToken)
    {
      var result = await _DeliveryVoucherService.ConfirmDeliveryVoucherAsync(request.Id);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Success<string>("Confirmed");
      }
      else
      {
        return BadRequest<string>(result);
      }


    }

    public async Task<Response<string>> Handle(RejectDeliveryVoucherCommand request, CancellationToken cancellationToken)
    {
      var result = await _DeliveryVoucherService.RejectDeliveryVoucherAsync(request.Id);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Success<string>("Rejected");
      }
      else
      {
        return BadRequest<string>(result);
      }

    }
  }
}
