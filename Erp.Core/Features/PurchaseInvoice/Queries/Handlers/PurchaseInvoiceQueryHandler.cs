using AutoMapper;
using Erp.Core.Features.PurchaseInvoice.Queries.Models;
using Erp.Data.Dto.PurchaseInvoice;
using Erp.Service.Abstracts;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.PurchaseInvoice.Queries.Handlers
{
  public class PurchaseInvoiceQueryHandler : ResponseHandler,
    IRequestHandler<GetPurchaseInvoiceByIdQuery, Response<GetPurchaseInvoiceByIdDto>>,
    IRequestHandler<GetPurchaseInvoiceListQuery, Response<List<GetPurchaseInvoiceByIdDto>>>
  {
    private readonly IPurchaseInvoiceService _PurchaseInvoiceService;
    private readonly IMapper _mapper;


    public PurchaseInvoiceQueryHandler(IPurchaseInvoiceService PurchaseInvoiceService, IMapper mapper)
    {
      _PurchaseInvoiceService = PurchaseInvoiceService;
      _mapper = mapper;
    }



    public async Task<Response<List<GetPurchaseInvoiceByIdDto>>> Handle(GetPurchaseInvoiceListQuery request, CancellationToken cancellationToken)
    {
      var PurchaseInvoices = await _PurchaseInvoiceService.GetPurchaseInvoicesListAsync();


      return Success(PurchaseInvoices);

    }

    public async Task<Response<GetPurchaseInvoiceByIdDto>> Handle(GetPurchaseInvoiceByIdQuery request, CancellationToken cancellationToken)
    {
      var PurchaseInvoice = await _PurchaseInvoiceService.GetPurchaseInvoiceByIdAsync(request.Id);


      if (PurchaseInvoice == null)
      {
        return NotFound<GetPurchaseInvoiceByIdDto>("PurchaseInvoice Not Found");
      }
      else
      {

        return Success(PurchaseInvoice);
      }
    }
  }
}
