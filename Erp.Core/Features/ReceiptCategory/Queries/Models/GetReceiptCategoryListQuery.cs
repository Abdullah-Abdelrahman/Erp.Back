using Erp.Core.Features.ReceiptCategory.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.ReceiptCategory.Queries.Models
{
  public class GetReceiptCategoryListQuery : IRequest<Response<List<GetReceiptCategoryByIdResult>>>
  {
  }
}
