using Erp.Data.Dto.PurchaseInvoice;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.PurchaseInvoice.Queries.Models
{
  public class GetPurchaseInvoiceByIdQuery : IRequest<Response<GetPurchaseInvoiceByIdDto>>
  {
    public int Id { get; set; }

    public GetPurchaseInvoiceByIdQuery(int id)
    {
      Id = id;
    }
  }
}
