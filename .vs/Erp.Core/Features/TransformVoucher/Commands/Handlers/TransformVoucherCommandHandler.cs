using AutoMapper;
using Erp.Core.Features.TransformVoucher.Commands.Models;
using Erp.Data.Dto.TransformVoucher;
using Erp.Data.MetaData;
using Erp.Service.Abstracts;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.TransformVoucher.Commands.Handlers
{
  public class TransformVoucherCommandHandler : ResponseHandler,
    IRequestHandler<AddTransformVoucherCommand, Response<string>>,
    IRequestHandler<EditTransformVoucherCommand, Response<string>>,
  IRequestHandler<DeleteTransformVoucherCommand, Response<string>>


  {

    private readonly ITransformVoucherService _TransformVoucherService;
    private readonly IMapper _mapper;

    public TransformVoucherCommandHandler(ITransformVoucherService TransformVoucherService, IMapper mapper)
    {
      _TransformVoucherService = TransformVoucherService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddTransformVoucherCommand request, CancellationToken cancellationToken)
    {
      var AddTransformVoucherRequestMapper = _mapper.Map<AddTransformVoucherRequest>(request);
      var result = await _TransformVoucherService.AddTransformVoucher(AddTransformVoucherRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Added successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(EditTransformVoucherCommand request, CancellationToken cancellationToken)
    {

      var EditTransformVoucherRequestMapper = _mapper.Map<UpdateTransformVoucherRequest>(request);
      var result = await _TransformVoucherService.UpdateAsync(EditTransformVoucherRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }


    }

    public async Task<Response<string>> Handle(DeleteTransformVoucherCommand request, CancellationToken cancellationToken)
    {


      var result = await _TransformVoucherService.DeleteByIdAsync(request.Id);

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
