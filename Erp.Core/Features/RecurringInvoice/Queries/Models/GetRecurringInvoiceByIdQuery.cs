using Erp.Data.Dto.RecurringInvoice;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.RecurringInvoice.Queries.Models
{
  public class GetRecurringInvoiceByIdQuery : IRequest<Response<GetRecurringInvoiceByIdDto>>
  {
    public int Id { get; set; }

    public GetRecurringInvoiceByIdQuery(int id)
    {
      Id = id;
    }
  }
}
