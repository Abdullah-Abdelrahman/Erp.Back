using Erp.Data.Dto.TransformVoucher.cs;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.TransformVoucher.Queries.Models
{
  public class GetTransformVoucherListQuery : IRequest<Response<List<GetTransformVoucherByIdDto>>>
  {
  }
}
