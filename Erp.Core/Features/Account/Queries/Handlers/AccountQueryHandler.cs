using AutoMapper;
using Erp.Core.Features.Account.Queries.Models;
using Erp.Core.Features.Account.Queries.Results;
using Erp.Service.Abstracts.AccountsModule;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Account.Queries.Handlers
{
  public class AccountQueryHandler : ResponseHandler,
    IRequestHandler<GetMainAccountsListQuery, Response<List<GetPrimaryAccountByIdResult>>>, IRequestHandler<GetPrimaryAccountByIdQuery, Response<GetPrimaryAccountByIdResult>>,
    IRequestHandler<GetAccountTypeByIdQuery, Response<string>>,
    IRequestHandler<GetSecondaryAccountByIdQuery, Response<GetSecondaryAccountByIdResult>>, IRequestHandler<GetPrimaryAccountsListQuery, Response<List<GetPrimaryAccountByIdResult>>>, IRequestHandler<GetSecondaryAccountsListQuery, Response<List<GetSecondaryAccountByIdResult>>>
  {
    #region Fields
    private readonly IAccountService _AccountService;

    private readonly IMapper _mapper;
    #endregion
    public AccountQueryHandler(IAccountService AccountService, IMapper mapper)
    {
      _mapper = mapper;
      _AccountService = AccountService;
    }



    public async Task<Response<string>> Handle(GetAccountTypeByIdQuery request, CancellationToken cancellationToken)
    {
      var accountType = await _AccountService.GetAccountTypeByIdAsync(request.Id);
      return Success(accountType);
    }

    public async Task<Response<List<GetPrimaryAccountByIdResult>>> Handle(GetMainAccountsListQuery request, CancellationToken cancellationToken)
    {
      var primaryAccounts = await _AccountService.GetMainAccountListAsync();
      var result = _mapper.Map<List<GetPrimaryAccountByIdResult>>(primaryAccounts);
      return Success(result);
    }

    public async Task<Response<GetPrimaryAccountByIdResult>> Handle(GetPrimaryAccountByIdQuery request, CancellationToken cancellationToken)
    {
      var primaryAccount = await _AccountService.
        GetPrimaryAccountByIdAsync(request.Id);


      if (primaryAccount == null)
      {
        return NotFound<GetPrimaryAccountByIdResult>("Primary Account Not Found");
      }

      var result = _mapper.Map<GetPrimaryAccountByIdResult>(primaryAccount);
      return Success(result);
    }

    public async Task<Response<GetSecondaryAccountByIdResult>> Handle(GetSecondaryAccountByIdQuery request, CancellationToken cancellationToken)
    {
      var secondaryAccount = await _AccountService.GetSecondaryAccountByIdAsync(request.Id);
      if (secondaryAccount == null)
      {
        return NotFound<GetSecondaryAccountByIdResult>("Secondary Account Not Found");
      }

      var result = _mapper.Map<GetSecondaryAccountByIdResult>(secondaryAccount);
      return Success(result);
    }

    public async Task<Response<List<GetPrimaryAccountByIdResult>>> Handle(GetPrimaryAccountsListQuery request, CancellationToken cancellationToken)
    {
      var primaryAccounts = await _AccountService.GetPrimaryAccountListAsync();
      var result = _mapper.Map<List<GetPrimaryAccountByIdResult>>(primaryAccounts);
      return Success(result);
    }

    public async Task<Response<List<GetSecondaryAccountByIdResult>>> Handle(GetSecondaryAccountsListQuery request, CancellationToken cancellationToken)
    {
      var SecondaryAccounts = await _AccountService.GetSecondaryAccountListAsync();
      var result = _mapper.Map<List<GetSecondaryAccountByIdResult>>(SecondaryAccounts);
      return Success(result);
    }
  }
}
