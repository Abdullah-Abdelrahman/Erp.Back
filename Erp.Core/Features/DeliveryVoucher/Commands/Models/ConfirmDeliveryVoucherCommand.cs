using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.DeliveryVoucher.Commands.Models
{
  public class ConfirmDeliveryVoucherCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public ConfirmDeliveryVoucherCommand(int id)
    {
      Id = id;
    }

  }
}
