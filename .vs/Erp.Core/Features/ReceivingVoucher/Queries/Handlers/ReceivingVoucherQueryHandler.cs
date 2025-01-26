using AutoMapper;
using Erp.Core.Features.ReceivingVoucher.Queries.Models;
using Erp.Data.Dto.ReceivingVoucher;
using Erp.Service.Abstracts;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.ReceivingVoucher.Queries.Handlers
{
  public class ReceivingVoucherQueryHandler : ResponseHandler,
    IRequestHandler<GetReceivingVoucherByIdQuery, Response<GetReceivingVoucherByIdDto>>,
    IRequestHandler<GetReceivingVoucherListQuery, Response<List<GetReceivingVoucherByIdDto>>>
  {
    private readonly IReceivingVoucherService _receivingVoucherService;
    private readonly IMapper _mapper;


    public ReceivingVoucherQueryHandler(IReceivingVoucherService receivingVoucherService, IMapper mapper)
    {
      _receivingVoucherService = receivingVoucherService;
      _mapper = mapper;
    }



    public async Task<Response<List<GetReceivingVoucherByIdDto>>> Handle(GetReceivingVoucherListQuery request, CancellationToken cancellationToken)
    {
      var ReceivingVouchers = await _receivingVoucherService.GetReceivingVouchersListAsync();


      return Success(ReceivingVouchers);

    }

    public async Task<Response<GetReceivingVoucherByIdDto>> Handle(GetReceivingVoucherByIdQuery request, CancellationToken cancellationToken)
    {
      var ReceivingVoucher = await _receivingVoucherService.GetReceivingVoucherByIdAsync(request.Id);


      if (ReceivingVoucher == null)
      {
        return NotFound<GetReceivingVoucherByIdDto>("ReceivingVoucher Not Found");
      }
      else
      {

        return Success(ReceivingVoucher);
      }
    }
  }
}
