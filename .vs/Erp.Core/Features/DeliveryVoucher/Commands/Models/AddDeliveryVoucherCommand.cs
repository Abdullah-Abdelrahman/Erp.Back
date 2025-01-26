using Erp.Data.Dto.DeliveryVoucher;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.DeliveryVoucher.Commands.Models
{
  public class AddDeliveryVoucherCommand : AddDeliveryVoucherRequest, IRequest<Response<string>>
  {

  }
}
