using Erp.Data.Dto.PurchaseReturn;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.PurchaseReturn.Queries.Models
{
  public class GetPurchaseReturnListQuery : IRequest<Response<List<GetPurchaseReturnByIdDto>>>
  {
  }
}
