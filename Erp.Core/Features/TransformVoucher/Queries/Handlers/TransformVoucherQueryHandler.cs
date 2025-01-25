using AutoMapper;
using Erp.Core.Features.TransformVoucher.Queries.Models;
using Erp.Data.Dto.TransformVoucher.cs;
using Erp.Service.Abstracts;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.TransformVoucher.Queries.Handlers
{
  public class TransformVoucherQueryHandler : ResponseHandler,
    IRequestHandler<GetTransformVoucherByIdQuery, Response<GetTransformVoucherByIdDto>>,
    IRequestHandler<GetTransformVoucherListQuery, Response<List<GetTransformVoucherByIdDto>>>
  {
    private readonly ITransformVoucherService _TransformVoucherService;
    private readonly IMapper _mapper;


    public TransformVoucherQueryHandler(ITransformVoucherService TransformVoucherService, IMapper mapper)
    {
      _TransformVoucherService = TransformVoucherService;
      _mapper = mapper;
    }



    public async Task<Response<List<GetTransformVoucherByIdDto>>> Handle(GetTransformVoucherListQuery request, CancellationToken cancellationToken)
    {
      var TransformVouchers = await _TransformVoucherService.GetTransformVouchersListAsync();


      return Success(TransformVouchers);

    }

    public async Task<Response<GetTransformVoucherByIdDto>> Handle(GetTransformVoucherByIdQuery request, CancellationToken cancellationToken)
    {
      var TransformVoucher = await _TransformVoucherService.GetTransformVoucherByIdAsync(request.Id);


      if (TransformVoucher == null)
      {
        return NotFound<GetTransformVoucherByIdDto>("TransformVoucher Not Found");
      }
      else
      {

        return Success(TransformVoucher);
      }
    }
  }
}
