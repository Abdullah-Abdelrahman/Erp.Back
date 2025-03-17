using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.DeliveryVoucher.Commands.Models
{
  public class RejectDeliveryVoucherCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public RejectDeliveryVoucherCommand(int id)
    {
      Id = id;
    }

  }
}
