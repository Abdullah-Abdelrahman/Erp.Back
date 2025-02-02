using AutoMapper;
using Erp.Core.Features.RecurringInvoice.Commands.Models;
using Erp.Data.Dto.RecurringInvoice;
using Erp.Data.MetaData;
using Erp.Service.Abstracts.SalesModule;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.RecurringInvoice.Commands.Handlers
{
  public class RecurringInvoiceCommandHandler : ResponseHandler,
    IRequestHandler<AddRecurringInvoiceCommand, Response<string>>,
    IRequestHandler<EditRecurringInvoiceCommand, Response<string>>,
  IRequestHandler<DeleteRecurringInvoiceCommand, Response<string>>


  {

    private readonly IRecurringInvoiceService _RecurringInvoiceService;
    private readonly IMapper _mapper;

    public RecurringInvoiceCommandHandler(IRecurringInvoiceService RecurringInvoiceService, IMapper mapper)
    {
      _RecurringInvoiceService = RecurringInvoiceService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddRecurringInvoiceCommand request, CancellationToken cancellationToken)
    {
      var AddRecurringInvoiceRequestMapper = _mapper.Map<AddRecurringInvoiceRequest>(request);
      var result = await _RecurringInvoiceService.AddRecurringInvoice(AddRecurringInvoiceRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Added successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(EditRecurringInvoiceCommand request, CancellationToken cancellationToken)
    {

      var EditRecurringInvoiceRequestMapper = _mapper.Map<UpdateRecurringInvoiceRequest>(request);
      var result = await _RecurringInvoiceService.UpdateAsync(EditRecurringInvoiceRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }


    }

    public async Task<Response<string>> Handle(DeleteRecurringInvoiceCommand request, CancellationToken cancellationToken)
    {


      var result = await _RecurringInvoiceService.DeleteByIdAsync(request.Id);

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
