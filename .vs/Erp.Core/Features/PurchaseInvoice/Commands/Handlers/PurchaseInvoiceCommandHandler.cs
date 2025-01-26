using AutoMapper;
using Erp.Core.Features.PurchaseInvoice.Commands.Models;
using Erp.Data.Dto.PurchaseInvoice;
using Erp.Data.MetaData;
using Erp.Service.Abstracts;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.PurchaseInvoice.Commands.Handlers
{
  public class PurchaseInvoiceCommandHandler : ResponseHandler,
    IRequestHandler<AddPurchaseInvoiceCommand, Response<string>>,
    IRequestHandler<EditPurchaseInvoiceCommand, Response<string>>,
  IRequestHandler<DeletePurchaseInvoiceCommand, Response<string>>


  {

    private readonly IPurchaseInvoiceService _PurchaseInvoiceService;
    private readonly IMapper _mapper;

    public PurchaseInvoiceCommandHandler(IPurchaseInvoiceService PurchaseInvoiceService, IMapper mapper)
    {
      _PurchaseInvoiceService = PurchaseInvoiceService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddPurchaseInvoiceCommand request, CancellationToken cancellationToken)
    {
      var AddPurchaseInvoiceRequestMapper = _mapper.Map<AddPurchaseInvoiceRequest>(request);
      var result = await _PurchaseInvoiceService.AddPurchaseInvoice(AddPurchaseInvoiceRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Added successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(EditPurchaseInvoiceCommand request, CancellationToken cancellationToken)
    {

      var EditPurchaseInvoiceRequestMapper = _mapper.Map<UpdatePurchaseInvoiceRequest>(request);
      var result = await _PurchaseInvoiceService.UpdateAsync(EditPurchaseInvoiceRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }


    }

    public async Task<Response<string>> Handle(DeletePurchaseInvoiceCommand request, CancellationToken cancellationToken)
    {


      var result = await _PurchaseInvoiceService.DeleteByIdAsync(request.Id);

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
