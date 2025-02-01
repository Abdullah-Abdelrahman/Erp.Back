using AutoMapper;
using Erp.Core.Features.Invoice.Queries.Models;
using Erp.Data.Dto.Invoice;
using Erp.Service.Abstracts.SalesModule;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Invoice.Queries.Handlers
{
  public class InvoiceQueryHandler : ResponseHandler,
    IRequestHandler<GetInvoiceByIdQuery, Response<GetInvoiceByIdDto>>,
    IRequestHandler<GetInvoiceListQuery, Response<List<GetInvoiceByIdDto>>>
  {
    private readonly IInvoiceService _InvoiceService;
    private readonly IMapper _mapper;


    public InvoiceQueryHandler(IInvoiceService InvoiceService, IMapper mapper)
    {
      _InvoiceService = InvoiceService;
      _mapper = mapper;
    }



    public async Task<Response<List<GetInvoiceByIdDto>>> Handle(GetInvoiceListQuery request, CancellationToken cancellationToken)
    {
      var Invoices = await _InvoiceService.GetInvoicesListAsync();


      return Success(Invoices);

    }

    public async Task<Response<GetInvoiceByIdDto>> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
    {
      var Invoice = await _InvoiceService.GetInvoiceByIdAsync(request.Id);


      if (Invoice == null)
      {
        return NotFound<GetInvoiceByIdDto>("Invoice Not Found");
      }
      else
      {

        return Success(Invoice);
      }
    }
  }
}
