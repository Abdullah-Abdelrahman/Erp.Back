using Erp.Data.Dto.Customer;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Customer.Queries.Models
{
  public class GetCommercialCustomerByIdQuery : IRequest<Response<GetCommercialCustomerByIdDto>>
  {
    public int Id { get; set; }

    public GetCommercialCustomerByIdQuery(int id)
    {
      Id = id;
    }
  }
}
