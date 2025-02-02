using AutoMapper;
using Erp.Core.Features.CustomerPayment.Queries.Models;
using Erp.Core.Features.CustomerPayment.Queries.Results;
using Erp.Service.Abstracts.SalesModule;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.CustomerPayment.Queries.Handlers
{
  public class CustomerPaymentQueryHandler : ResponseHandler, IRequestHandler<GetCustomerPaymentByIdQuery, Response<GetCustomerPaymentByIdResult>>, IRequestHandler<GetCustomerPaymentListQuery, Response<List<GetCustomerPaymentByIdResult>>>
  {
    #region Fields
    private readonly ICustomerPaymentService _CustomerPaymentService;

    private readonly IMapper _mapper;
    #endregion
    public CustomerPaymentQueryHandler(ICustomerPaymentService CustomerPaymentService, IMapper mapper)
    {
      _mapper = mapper;
      _CustomerPaymentService = CustomerPaymentService;
    }

    public async Task<Response<GetCustomerPaymentByIdResult>> Handle(GetCustomerPaymentByIdQuery request, CancellationToken cancellationToken)
    {
      var CustomerPayment = await _CustomerPaymentService.GetCustomerPaymentByIdAsync(request.Id);


      if (CustomerPayment == null)
      {
        return NotFound<GetCustomerPaymentByIdResult>("CustomerPayment Not Found");
      }
      else
      {
        var CustomerPaymentMapper = _mapper.Map<GetCustomerPaymentByIdResult>(CustomerPayment);
        return Success(CustomerPaymentMapper);
      }
    }

    public async Task<Response<List<GetCustomerPaymentByIdResult>>> Handle(GetCustomerPaymentListQuery request, CancellationToken cancellationToken)
    {
      var CustomerPaymentList = await _CustomerPaymentService.GetCustomerPaymentsListAsync();

      var CustomerPaymentListMapper = _mapper.Map<List<GetCustomerPaymentByIdResult>>(CustomerPaymentList);

      return Success(CustomerPaymentListMapper);
    }
  }
}
