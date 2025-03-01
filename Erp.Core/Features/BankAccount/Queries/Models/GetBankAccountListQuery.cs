using Erp.Data.Dto.BankAccount;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.BankAccount.Queries.Models
{
  public class GetBankAccountListQuery : IRequest<Response<List<GetBankAccountByIdDto>>>
  {
  }
}
