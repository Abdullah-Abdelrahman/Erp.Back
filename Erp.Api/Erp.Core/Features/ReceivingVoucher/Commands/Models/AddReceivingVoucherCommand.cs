using Erp.Data.Dto.ReceivingVoucher;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.ReceivingVoucher.Commands.Models
{
  public class AddReceivingVoucherCommand : AddReceivingVoucherRequest, IRequest<Response<string>>
  {

  }
}
