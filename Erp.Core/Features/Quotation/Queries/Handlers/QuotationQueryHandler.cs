using AutoMapper;
using Erp.Core.Features.Quotation.Queries.Models;
using Erp.Data.Dto.Quotation;
using Erp.Service.Abstracts.SalesModule;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Quotation.Queries.Handlers
{
  public class QuotationQueryHandler : ResponseHandler,
    IRequestHandler<GetQuotationByIdQuery, Response<GetQuotationByIdDto>>,
    IRequestHandler<GetQuotationListQuery, Response<List<GetQuotationByIdDto>>>
  {
    private readonly IQuotationService _QuotationService;
    private readonly IMapper _mapper;


    public QuotationQueryHandler(IQuotationService QuotationService, IMapper mapper)
    {
      _QuotationService = QuotationService;
      _mapper = mapper;
    }



    public async Task<Response<List<GetQuotationByIdDto>>> Handle(GetQuotationListQuery request, CancellationToken cancellationToken)
    {
      var Quotations = await _QuotationService.GetQuotationsListAsync();


      return Success(Quotations);

    }

    public async Task<Response<GetQuotationByIdDto>> Handle(GetQuotationByIdQuery request, CancellationToken cancellationToken)
    {
      var Quotation = await _QuotationService.GetQuotationByIdAsync(request.Id);


      if (Quotation == null)
      {
        return NotFound<GetQuotationByIdDto>("Quotation Not Found");
      }
      else
      {

        return Success(Quotation);
      }
    }
  }
}
