using Erp.Core.Features.CustomerPayment.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.CustomerPayment.Queries.Models
{
  public class GetCustomerPaymentByIdQuery : IRequest<Response<GetCustomerPaymentByIdResult>>
  {
    public int Id { get; set; }

    public GetCustomerPaymentByIdQuery(int id)
    {
      Id = id;
    }
  }
}
