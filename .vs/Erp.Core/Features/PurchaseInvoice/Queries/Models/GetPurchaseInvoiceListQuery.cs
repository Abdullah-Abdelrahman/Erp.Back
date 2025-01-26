using Erp.Data.Dto.PurchaseInvoice;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.PurchaseInvoice.Queries.Models
{
  public class GetPurchaseInvoiceListQuery : IRequest<Response<List<GetPurchaseInvoiceByIdDto>>>
  {
  }
}
