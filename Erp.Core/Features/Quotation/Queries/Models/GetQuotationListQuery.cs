using Erp.Data.Dto.Quotation;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Quotation.Queries.Models
{
  public class GetQuotationListQuery : IRequest<Response<List<GetQuotationByIdDto>>>
  {
  }
}
