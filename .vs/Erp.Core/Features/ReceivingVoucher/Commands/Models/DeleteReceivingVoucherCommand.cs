using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.ReceivingVoucher.Commands.Models
{
  public class DeleteReceivingVoucherCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public DeleteReceivingVoucherCommand(int id)
    {
      Id = id;
    }

  }
}
