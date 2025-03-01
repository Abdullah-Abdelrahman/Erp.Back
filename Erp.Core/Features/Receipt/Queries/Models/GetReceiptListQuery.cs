using Erp.Data.Dto.Receipt;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Receipt.Queries.Models
{
  public class GetReceiptListQuery : IRequest<Response<List<GetReceiptByIdDto>>>
  {
  }
}
