using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.BankAccount.Commands.Models
{
  public class DeleteBankAccountCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public DeleteBankAccountCommand(int id)
    {
      Id = id;
    }

  }
}
