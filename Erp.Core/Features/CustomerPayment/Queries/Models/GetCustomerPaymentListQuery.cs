using Erp.Core.Features.CustomerPayment.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.CustomerPayment.Queries.Models
{
  public class GetCustomerPaymentListQuery : IRequest<Response<List<GetCustomerPaymentByIdResult>>>
  {
  }
}
