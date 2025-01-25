using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.DeliveryVoucher.Commands.Models
{
  public class DeleteDeliveryVoucherCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public DeleteDeliveryVoucherCommand(int id)
    {
      Id = id;
    }

  }
}
