using Erp.Core.Features.BankAccount.Commands.Models;
using Erp.Core.Features.BankAccount.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BankAccountController : AppControllerBase
  {


    [HttpPost(Router.BankAccountRouter.Create)]
    //[Authorize(Policy = "CreateProduct")]
    public async Task<IActionResult> CreateBankAccount([FromBody] AddBankAccountCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }

    [HttpGet(Router.BankAccountRouter.GetList)]
    public async Task<IActionResult> GetBankAccountList()
    {
      var response = await Mediator.Send(new GetBankAccountListQuery());

      return Ok(response);
    }


    [HttpGet(Router.BankAccountRouter.GetById)]
    public async Task<IActionResult> GetBankAccountById(int Id)
    {
      var response = await Mediator.Send(new GetBankAccountByIdQuery(Id));

      return NewResult(response);
    }

    [HttpPut(Router.BankAccountRouter.Edit)]
    public async Task<IActionResult> EditBankAccount([FromBody] EditBankAccountCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.BankAccountRouter.Delete)]
    public async Task<IActionResult> DeleteBankAccountById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteBankAccountCommand(Id));

      return NewResult(response);
    }


  }
}
