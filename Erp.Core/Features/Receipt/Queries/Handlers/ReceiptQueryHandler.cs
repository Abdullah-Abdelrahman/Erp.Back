using AutoMapper;
using Erp.Core.Features.Receipt.Queries.Models;
using Erp.Data.Dto.Receipt;
using Erp.Service.Abstracts.Finance;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Receipt.Queries.Handlers
{
  public class ReceiptQueryHandler : ResponseHandler,
    IRequestHandler<GetReceiptByIdQuery, Response<GetReceiptByIdDto>>,
    IRequestHandler<GetReceiptListQuery, Response<List<GetReceiptByIdDto>>>
  {
    private readonly IReceiptService _ReceiptService;
    private readonly IMapper _mapper;


    public ReceiptQueryHandler(IReceiptService ReceiptService, IMapper mapper)
    {
      _ReceiptService = ReceiptService;
      _mapper = mapper;
    }



    public async Task<Response<List<GetReceiptByIdDto>>> Handle(GetReceiptListQuery request, CancellationToken cancellationToken)
    {
      var Receipts = await _ReceiptService.GetReceiptsListAsync();


      return Success(Receipts);

    }

    public async Task<Response<GetReceiptByIdDto>> Handle(GetReceiptByIdQuery request, CancellationToken cancellationToken)
    {
      var Receipt = await _ReceiptService.GetReceiptByIdAsync(request.Id);


      if (Receipt == null)
      {
        return NotFound<GetReceiptByIdDto>("Receipt Not Found");
      }
      else
      {

        return Success(Receipt);
      }
    }
  }
}
