using AutoMapper;
using Erp.Core.Features.DeliveryVoucher.Queries.Models;
using Erp.Data.Dto.DeliveryVoucher;
using Erp.Service.Abstracts;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.DeliveryVoucher.Queries.Handlers
{
  public class DeliveryVoucherQueryHandler : ResponseHandler,
    IRequestHandler<GetDeliveryVoucherByIdQuery, Response<GetDeliveryVoucherByIdDto>>,
    IRequestHandler<GetDeliveryVoucherListQuery, Response<List<GetDeliveryVoucherByIdDto>>>
  {
    private readonly IDeliveryVoucherService _DeliveryVoucherService;
    private readonly IMapper _mapper;


    public DeliveryVoucherQueryHandler(IDeliveryVoucherService DeliveryVoucherService, IMapper mapper)
    {
      _DeliveryVoucherService = DeliveryVoucherService;
      _mapper = mapper;
    }



    public async Task<Response<List<GetDeliveryVoucherByIdDto>>> Handle(GetDeliveryVoucherListQuery request, CancellationToken cancellationToken)
    {
      var DeliveryVouchers = await _DeliveryVoucherService.GetDeliveryVouchersListAsync();


      return Success(DeliveryVouchers);

    }

    public async Task<Response<GetDeliveryVoucherByIdDto>> Handle(GetDeliveryVoucherByIdQuery request, CancellationToken cancellationToken)
    {
      var DeliveryVoucher = await _DeliveryVoucherService.GetDeliveryVoucherByIdAsync(request.Id);


      if (DeliveryVoucher == null)
      {
        return NotFound<GetDeliveryVoucherByIdDto>("DeliveryVoucher Not Found");
      }
      else
      {

        return Success(DeliveryVoucher);
      }
    }
  }
}
