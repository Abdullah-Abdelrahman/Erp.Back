using Erp.Data.Dto.PurchaseReturn;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.PurchaseReturn.Queries.Models
{
  public class GetPurchaseReturnByIdQuery : IRequest<Response<GetPurchaseReturnByIdDto>>
  {
    public int Id { get; set; }

    public GetPurchaseReturnByIdQuery(int id)
    {
      Id = id;
    }
  }
}
