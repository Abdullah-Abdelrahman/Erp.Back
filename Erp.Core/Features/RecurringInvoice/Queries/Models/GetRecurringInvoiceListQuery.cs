using Erp.Data.Dto.RecurringInvoice;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.RecurringInvoice.Queries.Models
{
  public class GetRecurringInvoiceListQuery : IRequest<Response<List<GetRecurringInvoiceByIdDto>>>
  {
  }
}
