using Erp.Core.Features.CustomerClassification.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.CustomerClassification.Queries.Models
{
  public class GetCustomerClassificationListQuery : IRequest<Response<List<GetCustomerClassificationByIdResult>>>
  {
  }
}
