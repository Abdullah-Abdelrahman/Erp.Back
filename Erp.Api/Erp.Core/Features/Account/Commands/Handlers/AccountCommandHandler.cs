using AutoMapper;
using Erp.Core.Features.Account.Commands.Models;
using Erp.Data.Entities.AccountsModule;
using Erp.Data.MetaData;
using Erp.Service.Abstracts.AccountsModule;
using MediatR;
using Name.Core.Bases;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Features.Account.Commands.Handlers
{

  public class AccountCommandHandler : ResponseHandler,
    IRequestHandler<AddAccountCommand, Response<string>>,
     IRequestHandler<EditAccountCommand, Response<string>>,
     IRequestHandler<DeleteAccountCommand, Response<string>>
  {
    private readonly IAccountService _AccountService;
    private readonly IMapper _mapper;

    public AccountCommandHandler(IAccountService AccountService, IMapper mapper)
    {
      _AccountService = AccountService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddAccountCommand request, CancellationToken cancellationToken)
    {

      Entitis.AccountsModule.Account AccountMapper = null!;
      switch (request.PrimaryOrSecondary)
      {
        case PrimaryOrSecondary.Primary:
          AccountMapper = _mapper.Map<PrimaryAccount>(request);
          break;
        case PrimaryOrSecondary.Secondary:
          AccountMapper = _mapper.Map<SecondaryAccount>(request);
          break;
        default:
          return new Response<string>("Unknown account type");
      }

      var result = await _AccountService.AddAccountAsync(AccountMapper);

      if (result == MessageCenter.CrudMessage.Exist)
      {
        return UnprocessableEntity<string>("Exist Befor");
      }
      else if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Added successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(EditAccountCommand request, CancellationToken cancellationToken)
    {
      var AccountMapper = _mapper.Map<Entitis.AccountsModule.Account>(request);
      var result = await _AccountService.UpdateAccountAsync(AccountMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
    {
      var AccountInDB = await _AccountService.GetAccountByIdAsync(request.Id);


      if (AccountInDB == null)
      {
        return NotFound<string>("There is no Account with this id");
      }
      else
      {

        var result = await _AccountService.DeleteAccountAsync(AccountInDB.AccountID);

        if (result == MessageCenter.CrudMessage.Success)
        {
          return Deleted<string>();
        }
        else
        {
          return BadRequest<string>(MessageCenter.CrudMessage.Falied);
        }



      }
    }
  }
}

