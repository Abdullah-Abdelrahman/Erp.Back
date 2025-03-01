using Erp.Data.Dto.BankAccount;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.BankAccount.Queries.Models
{
  public class GetBankAccountByIdQuery : IRequest<Response<GetBankAccountByIdDto>>
  {
    public int Id { get; set; }

    public GetBankAccountByIdQuery(int id)
    {
      Id = id;
    }
  }
}
