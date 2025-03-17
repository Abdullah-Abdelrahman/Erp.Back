using Erp.Core.Features.Payment.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Payment.Queries.Models
{
  public class GetSupplierPaymentListQuery : IRequest<Response<List<GetSupplierPaymentByIdResult>>>
  {
  }
}
