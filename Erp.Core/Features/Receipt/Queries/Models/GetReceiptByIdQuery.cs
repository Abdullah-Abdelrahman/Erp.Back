using Erp.Data.Dto.Receipt;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Receipt.Queries.Models
{
  public class GetReceiptByIdQuery : IRequest<Response<GetReceiptByIdDto>>
  {
    public int Id { get; set; }

    public GetReceiptByIdQuery(int id)
    {
      Id = id;
    }
  }
}
