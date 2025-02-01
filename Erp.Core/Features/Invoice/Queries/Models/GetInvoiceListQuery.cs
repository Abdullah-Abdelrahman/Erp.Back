using Erp.Data.Dto.Invoice;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Invoice.Queries.Models
{
  public class GetInvoiceListQuery : IRequest<Response<List<GetInvoiceByIdDto>>>
  {
  }
}
