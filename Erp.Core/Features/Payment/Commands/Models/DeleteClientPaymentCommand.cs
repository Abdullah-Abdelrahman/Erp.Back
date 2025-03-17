using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Payment.Commands.Models
{
  public class DeleteClientPaymentCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public DeleteClientPaymentCommand(int id)
    {
      Id = id;
    }
  }

}
