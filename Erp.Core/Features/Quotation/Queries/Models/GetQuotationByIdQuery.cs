using Erp.Data.Dto.Quotation;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Quotation.Queries.Models
{
  public class GetQuotationByIdQuery : IRequest<Response<GetQuotationByIdDto>>
  {
    public int Id { get; set; }

    public GetQuotationByIdQuery(int id)
    {
      Id = id;
    }
  }
}
