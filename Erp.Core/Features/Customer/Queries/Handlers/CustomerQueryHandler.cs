using AutoMapper;
using Erp.Core.Features.Customer.Queries.Models;
using Erp.Data.Dto.Customer;
using Erp.Service.Abstracts.CustomersModule;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Customer.Queries.Handlers
{
  public class CustomerQueryHandler : ResponseHandler, IRequestHandler<GetCommercialCustomerByIdQuery, Response<GetCommercialCustomerByIdDto>>,
    IRequestHandler<GetCustomerTypeByIdQuery, Response<string>>,
    IRequestHandler<GetIndividualCustomerByIdQuery, Response<GetIndividualCustomerByIdDto>>
  {
    #region Fields
    private readonly ICustomerService _CustomerService;

    private readonly IMapper _mapper;
    #endregion
    public CustomerQueryHandler(ICustomerService CustomerService, IMapper mapper)
    {
      _mapper = mapper;
      _CustomerService = CustomerService;
    }



    public async Task<Response<string>> Handle(GetCustomerTypeByIdQuery request, CancellationToken cancellationToken)
    {
      var CustomerType = await _CustomerService.GetCustomerTypeByIdAsync(request.Id);
      return Success(CustomerType);
    }



    public async Task<Response<GetCommercialCustomerByIdDto>> Handle(GetCommercialCustomerByIdQuery request, CancellationToken cancellationToken)
    {
      var CommercialCustomer = await _CustomerService.
        GetCommercialCustomerByIdAsync(request.Id);


      if (CommercialCustomer == null)
      {
        return NotFound<GetCommercialCustomerByIdDto>("Commercial Customer Not Found");
      }

      var result = _mapper.Map<GetCommercialCustomerByIdDto>(CommercialCustomer);
      return Success(result);
    }

    public async Task<Response<GetIndividualCustomerByIdDto>> Handle(GetIndividualCustomerByIdQuery request, CancellationToken cancellationToken)
    {
      var IndividualCustomer = await _CustomerService.GetIndividualCustomerByIdAsync(request.Id);
      if (IndividualCustomer == null)
      {
        return NotFound<GetIndividualCustomerByIdDto>("Individual Customer Not Found");
      }

      var result = _mapper.Map<GetIndividualCustomerByIdDto>(IndividualCustomer);
      return Success(result);
    }
  }
}
