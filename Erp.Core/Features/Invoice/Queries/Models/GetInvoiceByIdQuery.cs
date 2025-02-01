using Erp.Data.Dto.Invoice;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Invoice.Queries.Models
{
  public class GetInvoiceByIdQuery : IRequest<Response<GetInvoiceByIdDto>>
  {
    public int Id { get; set; }

    public GetInvoiceByIdQuery(int id)
    {
      Id = id;
    }
  }
}
