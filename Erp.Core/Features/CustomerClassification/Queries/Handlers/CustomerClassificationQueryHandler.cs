using AutoMapper;
using Erp.Core.Features.CustomerClassification.Queries.Models;
using Erp.Core.Features.CustomerClassification.Queries.Results;
using Erp.Service.Abstracts.CustomersModule;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.CustomerClassification.Queries.Handlers
{
  public class CustomerClassificationQueryHandler : ResponseHandler, IRequestHandler<GetCustomerClassificationByIdQuery, Response<GetCustomerClassificationByIdResult>>, IRequestHandler<GetCustomerClassificationListQuery, Response<List<GetCustomerClassificationByIdResult>>>
  {
    #region Fields
    private readonly ICustomerClassificationService _CustomerClassificationService;
    private readonly IMapper _mapper;
    #endregion
    public CustomerClassificationQueryHandler(ICustomerClassificationService CustomerClassificationService, IMapper mapper)
    {
      _mapper = mapper;
      _CustomerClassificationService = CustomerClassificationService;
    }

    public async Task<Response<GetCustomerClassificationByIdResult>> Handle(GetCustomerClassificationByIdQuery request, CancellationToken cancellationToken)
    {
      var CustomerClassification = await _CustomerClassificationService.GetCustomerClassificationByIdAsync(request.Id);


      if (CustomerClassification == null)
      {
        return NotFound<GetCustomerClassificationByIdResult>("CustomerClassification Not Found");
      }
      else
      {
        var CustomerClassificationMapper = _mapper.Map<GetCustomerClassificationByIdResult>(CustomerClassification);
        return Success(CustomerClassificationMapper);
      }
    }

    public async Task<Response<List<GetCustomerClassificationByIdResult>>> Handle(GetCustomerClassificationListQuery request, CancellationToken cancellationToken)
    {
      var CustomerClassificationList = await _CustomerClassificationService.GetCustomerClassificationsListAsync();

      var CustomerClassificationListMapper = _mapper.Map<List<GetCustomerClassificationByIdResult>>(CustomerClassificationList);

      return Success(CustomerClassificationListMapper);
    }
  }
}
