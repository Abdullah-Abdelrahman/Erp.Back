using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.ReceivingVoucher.Commands.Models
{
  public class RejectReceivingVoucherCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public RejectReceivingVoucherCommand(int id)
    {
      Id = id;
    }

  }
}

