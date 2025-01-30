using Erp.Data.Dto.Customer;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Customer.Queries.Models
{
  public class GetIndividualCustomerByIdQuery : IRequest<Response<GetIndividualCustomerByIdDto>>
  {
    public int Id { get; set; }

    public GetIndividualCustomerByIdQuery(int id)
    {
      Id = id;
    }
  }
}
