using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.ReceivingVoucher.Commands.Models
{
  public class ConfirmReceivingVoucherCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public ConfirmReceivingVoucherCommand(int id)
    {
      Id = id;
    }
  }
}
