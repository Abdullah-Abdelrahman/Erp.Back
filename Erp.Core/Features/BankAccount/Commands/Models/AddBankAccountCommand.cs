using Erp.Data.Dto.BankAccount;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.BankAccount.Commands.Models
{
  public class AddBankAccountCommand : AddBankAccountRequest, IRequest<Response<string>>
  {

  }
}
