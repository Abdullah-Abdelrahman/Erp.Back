using AutoMapper;
using Erp.Core.Features.PurchaseReturn.Queries.Models;
using Erp.Data.Dto.PurchaseReturn;
using Erp.Service.Abstracts;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.PurchaseReturn.Queries.Handlers
{
  public class PurchaseReturnQueryHandler : ResponseHandler,
    IRequestHandler<GetPurchaseReturnByIdQuery, Response<GetPurchaseReturnByIdDto>>,
    IRequestHandler<GetPurchaseReturnListQuery, Response<List<GetPurchaseReturnByIdDto>>>
  {
    private readonly IPurchaseReturnService _PurchaseReturnService;
    private readonly IMapper _mapper;


    public PurchaseReturnQueryHandler(IPurchaseReturnService PurchaseReturnService, IMapper mapper)
    {
      _PurchaseReturnService = PurchaseReturnService;
      _mapper = mapper;
    }



    public async Task<Response<List<GetPurchaseReturnByIdDto>>> Handle(GetPurchaseReturnListQuery request, CancellationToken cancellationToken)
    {
      var PurchaseReturns = await _PurchaseReturnService.GetPurchaseReturnsListAsync();


      return Success(PurchaseReturns);

    }

    public async Task<Response<GetPurchaseReturnByIdDto>> Handle(GetPurchaseReturnByIdQuery request, CancellationToken cancellationToken)
    {
      var PurchaseReturn = await _PurchaseReturnService.GetPurchaseReturnByIdAsync(request.Id);


      if (PurchaseReturn == null)
      {
        return NotFound<GetPurchaseReturnByIdDto>("PurchaseReturn Not Found");
      }
      else
      {

        return Success(PurchaseReturn);
      }
    }
  }
}
