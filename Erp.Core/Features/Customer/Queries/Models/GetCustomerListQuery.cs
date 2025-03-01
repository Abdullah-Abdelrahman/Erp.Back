using Erp.Data.Dto.Customer;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Customer.Queries.Models
{
  public class GetCustomerListQuery : IRequest<Response<List<GetCustomerListResponse>>>
  {
  }
}
