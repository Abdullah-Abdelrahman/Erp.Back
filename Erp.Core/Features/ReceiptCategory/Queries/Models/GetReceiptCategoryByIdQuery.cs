using Erp.Core.Features.ReceiptCategory.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.ReceiptCategory.Queries.Models
{
  public class GetReceiptCategoryByIdQuery : IRequest<Response<GetReceiptCategoryByIdResult>>
  {
    public int Id { get; set; }

    public GetReceiptCategoryByIdQuery(int id)
    {
      Id = id;
    }
  }
}
