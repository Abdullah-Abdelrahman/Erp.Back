using AutoMapper;
using Erp.Core.Features.Payment.Queries.Models;
using Erp.Core.Features.Payment.Queries.Results;
using Erp.Service.Abstracts.CommonUse;
using Erp.Service.Abstracts.InventoryModule;
using MediatR;
using Name.Core.Bases;
namespace Erp.Core.Features.Payment.Queries.Handlers
{
  public class PaymentQueryHandler : ResponseHandler,
    IRequestHandler<GetSupplierPaymentByIdQuery, Response<GetSupplierPaymentByIdResult>>, IRequestHandler<GetSupplierPaymentListQuery, Response<List<GetSupplierPaymentByIdResult>>>


  {
    #region Fields
    private readonly IPaymentService _paymentService;

    private readonly IMapper _mapper;
    #endregion
    public PaymentQueryHandler(IPaymentService paymentService,
      IMapper mapper,
      IProductAndServiceBaseService ProductAndService)
    {
      _mapper = mapper;
      _paymentService = paymentService;
    }



    public async Task<Response<GetSupplierPaymentByIdResult>> Handle(GetSupplierPaymentByIdQuery request, CancellationToken cancellationToken)
    {
      var SupplierPayment = await _paymentService.GetSupplierPaymentByIdAsync(request.Id);


      if (SupplierPayment == null)
      {
        return NotFound<GetSupplierPaymentByIdResult>("Supplier Payment Not Found");
      }
      else
      {
        var SupplierPaymentMapper = _mapper.Map<GetSupplierPaymentByIdResult>(SupplierPayment);
        return Success(SupplierPaymentMapper);
      }
    }

    public async Task<Response<List<GetSupplierPaymentByIdResult>>> Handle(GetSupplierPaymentListQuery request, CancellationToken cancellationToken)
    {
      var SupplierPaymentList = await _paymentService.GetSupplierPaymentListAsync();

      var SupplierPaymentListMapper = _mapper.Map<List<GetSupplierPaymentByIdResult>>(SupplierPaymentList);

      return Success(SupplierPaymentListMapper);
    }
  }
}
