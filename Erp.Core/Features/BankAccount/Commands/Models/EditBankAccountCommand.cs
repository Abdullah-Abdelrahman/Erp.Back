using Erp.Data.Dto.BankAccount;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.BankAccount.Commands.Models
{
  public class EditBankAccountCommand : UpdateBankAccountRequest, IRequest<Response<string>>
  {


  }
}
