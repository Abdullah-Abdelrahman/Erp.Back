using AutoMapper;
using Erp.Core.Features.BankAccount.Queries.Models;
using Erp.Data.Dto.BankAccount;
using Erp.Service.Abstracts.Finance;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.BankAccount.Queries.Handlers
{
  public class BankAccountQueryHandler : ResponseHandler,
    IRequestHandler<GetBankAccountByIdQuery, Response<GetBankAccountByIdDto>>,
    IRequestHandler<GetBankAccountListQuery, Response<List<GetBankAccountByIdDto>>>
  {
    private readonly IBankAccountService _BankAccountService;
    private readonly IMapper _mapper;


    public BankAccountQueryHandler(IBankAccountService BankAccountService, IMapper mapper)
    {
      _BankAccountService = BankAccountService;
      _mapper = mapper;
    }



    public async Task<Response<List<GetBankAccountByIdDto>>> Handle(GetBankAccountListQuery request, CancellationToken cancellationToken)
    {
      var BankAccounts = await _BankAccountService.GetBankAccountsListAsync();


      return Success(BankAccounts);

    }

    public async Task<Response<GetBankAccountByIdDto>> Handle(GetBankAccountByIdQuery request, CancellationToken cancellationToken)
    {
      var BankAccount = await _BankAccountService.GetBankAccountByIdAsync(request.Id);


      if (BankAccount == null)
      {
        return NotFound<GetBankAccountByIdDto>("BankAccount Not Found");
      }
      else
      {

        return Success(BankAccount);
      }
    }
  }
}
