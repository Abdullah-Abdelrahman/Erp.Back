using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Customer.Queries.Models
{
  public class GetCustomerTypeByIdQuery : IRequest<Response<string>>
  {
    public int Id { get; set; }

    public GetCustomerTypeByIdQuery(int id)
    {
      Id = id;
    }
  }
}
