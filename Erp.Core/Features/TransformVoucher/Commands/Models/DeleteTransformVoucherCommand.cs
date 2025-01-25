using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.TransformVoucher.Commands.Models
{
  public class DeleteTransformVoucherCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public DeleteTransformVoucherCommand(int id)
    {
      Id = id;
    }

  }
}
