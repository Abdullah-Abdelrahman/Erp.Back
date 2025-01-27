using Erp.Data.Dto.DeliveryVoucher;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.DeliveryVoucher.Queries.Models
{
  public class GetDeliveryVoucherListQuery : IRequest<Response<List<GetDeliveryVoucherByIdDto>>>
  {
  }
}
