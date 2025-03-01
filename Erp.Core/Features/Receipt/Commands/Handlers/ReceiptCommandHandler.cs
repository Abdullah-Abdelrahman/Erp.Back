using AutoMapper;
using Erp.Core.Features.Receipt.Commands.Models;
using Erp.Data.Dto.Receipt;
using Erp.Data.MetaData;
using Erp.Service.Abstracts.Finance;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Receipt.Commands.Handlers
{
  public class ReceiptCommandHandler : ResponseHandler,
    IRequestHandler<AddReceiptCommand, Response<string>>,
    IRequestHandler<EditReceiptCommand, Response<string>>,
  IRequestHandler<DeleteReceiptCommand, Response<string>>


  {

    private readonly IReceiptService _ReceiptService;
    private readonly IMapper _mapper;

    public ReceiptCommandHandler(IReceiptService ReceiptService, IMapper mapper)
    {
      _ReceiptService = ReceiptService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddReceiptCommand request, CancellationToken cancellationToken)
    {
      var AddReceiptRequestMapper = _mapper.Map<AddReceiptRequest>(request);
      var result = await _ReceiptService.AddReceipt(AddReceiptRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Added successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened :" + result);
      }
    }

    public async Task<Response<string>> Handle(EditReceiptCommand request, CancellationToken cancellationToken)
    {

      var EditReceiptRequestMapper = _mapper.Map<UpdateReceiptRequest>(request);
      var result = await _ReceiptService.UpdateAsync(EditReceiptRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }


    }

    public async Task<Response<string>> Handle(DeleteReceiptCommand request, CancellationToken cancellationToken)
    {


      var result = await _ReceiptService.DeleteByIdAsync(request.Id);

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
