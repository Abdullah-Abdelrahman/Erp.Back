using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Receipt.Commands.Models
{
  public class DeleteReceiptCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public DeleteReceiptCommand(int id)
    {
      Id = id;
    }

  }
}
