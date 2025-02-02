using AutoMapper;
using Erp.Core.Features.RecurringInvoice.Queries.Models;
using Erp.Data.Dto.RecurringInvoice;
using Erp.Service.Abstracts.SalesModule;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.RecurringInvoice.Queries.Handlers
{
  public class RecurringInvoiceQueryHandler : ResponseHandler,
    IRequestHandler<GetRecurringInvoiceByIdQuery, Response<GetRecurringInvoiceByIdDto>>,
    IRequestHandler<GetRecurringInvoiceListQuery, Response<List<GetRecurringInvoiceByIdDto>>>
  {
    private readonly IRecurringInvoiceService _RecurringInvoiceService;
    private readonly IMapper _mapper;


    public RecurringInvoiceQueryHandler(IRecurringInvoiceService RecurringInvoiceService, IMapper mapper)
    {
      _RecurringInvoiceService = RecurringInvoiceService;
      _mapper = mapper;
    }



    public async Task<Response<List<GetRecurringInvoiceByIdDto>>> Handle(GetRecurringInvoiceListQuery request, CancellationToken cancellationToken)
    {
      var RecurringInvoices = await _RecurringInvoiceService.GetRecurringInvoicesListAsync();


      return Success(RecurringInvoices);

    }

    public async Task<Response<GetRecurringInvoiceByIdDto>> Handle(GetRecurringInvoiceByIdQuery request, CancellationToken cancellationToken)
    {
      var RecurringInvoice = await _RecurringInvoiceService.GetRecurringInvoiceByIdAsync(request.Id);


      if (RecurringInvoice == null)
      {
        return NotFound<GetRecurringInvoiceByIdDto>("RecurringInvoice Not Found");
      }
      else
      {

        return Success(RecurringInvoice);
      }
    }
  }
}
