using AutoMapper;
using Erp.Core.Features.Invoice.Commands.Models;
using Erp.Data.Dto.Invoice;
using Erp.Data.MetaData;
using Erp.Service.Abstracts.SalesModule;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Invoice.Commands.Handlers
{
  public class InvoiceCommandHandler : ResponseHandler,
    IRequestHandler<AddInvoiceCommand, Response<string>>,
    IRequestHandler<EditInvoiceCommand, Response<string>>,
  IRequestHandler<DeleteInvoiceCommand, Response<string>>


  {

    private readonly IInvoiceService _InvoiceService;
    private readonly IMapper _mapper;

    public InvoiceCommandHandler(IInvoiceService InvoiceService, IMapper mapper)
    {
      _InvoiceService = InvoiceService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddInvoiceCommand request, CancellationToken cancellationToken)
    {
      var AddInvoiceRequestMapper = _mapper.Map<AddInvoiceRequest>(request);
      var result = await _InvoiceService.AddInvoice(AddInvoiceRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Added successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(EditInvoiceCommand request, CancellationToken cancellationToken)
    {

      var EditInvoiceRequestMapper = _mapper.Map<UpdateInvoiceRequest>(request);
      var result = await _InvoiceService.UpdateAsync(EditInvoiceRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }


    }

    public async Task<Response<string>> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
    {


      var result = await _InvoiceService.DeleteByIdAsync(request.Id);

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
