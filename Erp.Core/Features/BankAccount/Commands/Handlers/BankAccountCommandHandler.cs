using AutoMapper;
using Erp.Core.Features.BankAccount.Commands.Models;
using Erp.Data.Dto.BankAccount;
using Erp.Data.MetaData;
using Erp.Service.Abstracts.Finance;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.BankAccount.Commands.Handlers
{
  public class BankAccountCommandHandler : ResponseHandler,
    IRequestHandler<AddBankAccountCommand, Response<string>>,
    IRequestHandler<EditBankAccountCommand, Response<string>>,
  IRequestHandler<DeleteBankAccountCommand, Response<string>>


  {

    private readonly IBankAccountService _BankAccountService;
    private readonly IMapper _mapper;

    public BankAccountCommandHandler(IBankAccountService BankAccountService, IMapper mapper)
    {
      _BankAccountService = BankAccountService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddBankAccountCommand request, CancellationToken cancellationToken)
    {
      var AddBankAccountRequestMapper = _mapper.Map<AddBankAccountRequest>(request);
      var result = await _BankAccountService.AddBankAccount(AddBankAccountRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Added successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(EditBankAccountCommand request, CancellationToken cancellationToken)
    {

      var EditBankAccountRequestMapper = _mapper.Map<UpdateBankAccountRequest>(request);
      var result = await _BankAccountService.UpdateAsync(EditBankAccountRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened" + result);
      }


    }

    public async Task<Response<string>> Handle(DeleteBankAccountCommand request, CancellationToken cancellationToken)
    {


      var result = await _BankAccountService.DeleteByIdAsync(request.Id);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Deleted<string>();
      }
      else
      {
        return BadRequest<string>(result);
      }




    }



  }
}
