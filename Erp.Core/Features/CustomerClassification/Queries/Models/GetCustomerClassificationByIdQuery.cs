using Erp.Core.Features.CustomerClassification.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.CustomerClassification.Queries.Models
{
  public class GetCustomerClassificationByIdQuery : IRequest<Response<GetCustomerClassificationByIdResult>>
  {
    public int Id { get; set; }

    public GetCustomerClassificationByIdQuery(int id)
    {
      Id = id;
    }
  }
}
