using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.PurchaseReturn.Commands.Models
{
  public class DeletePurchaseReturnCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public DeletePurchaseReturnCommand(int id)
    {
      Id = id;
    }

  }
}
