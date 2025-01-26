using Erp.Data.Dto.ReceivingVoucher;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.ReceivingVoucher.Queries.Models
{
  public class GetReceivingVoucherListQuery : IRequest<Response<List<GetReceivingVoucherByIdDto>>>
  {
  }
}
