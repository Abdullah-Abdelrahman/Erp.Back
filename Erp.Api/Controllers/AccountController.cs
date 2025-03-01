using Erp.Core.Features.Account.Commands.Models;
using Erp.Core.Features.Account.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AccountController : AppControllerBase
  {

    public AccountController(IWebHostEnvironment webHostEnvironment)
    {
      _webHost = webHostEnvironment;
    }

    [HttpGet(Router.AccountRouter.GetMainAccountsList)]
    public async Task<IActionResult> GetMainAccountsList()
    {
      var response = await Mediator.Send(new GetMainAccountsListQuery());

      return Ok(response);
    }

    [HttpGet(Router.AccountRouter.GetPrimaryAccountsList)]
    public async Task<IActionResult> GetPrimaryAccountsList()
    {
      var response = await Mediator.Send(new GetPrimaryAccountsListQuery());

      return Ok(response);
    }

    [HttpGet(Router.AccountRouter.GetSecondaryAccountsList)]
    public async Task<IActionResult> GetSecondaryAccountsList()
    {
      var response = await Mediator.Send(new GetSecondaryAccountsListQuery());

      return Ok(response);
    }

    [HttpGet(Router.AccountRouter.GetAccountTypeById)]
    public async Task<IActionResult> GetAccountTypeById(int Id)
    {
      var response = await Mediator.Send(new GetAccountTypeByIdQuery(Id));

      return NewResult(response);
    }

    [HttpGet(Router.AccountRouter.GetSecondaryAccountById)]
    public async Task<IActionResult> GetSecondaryAccountByIdQuery(int Id)
    {
      var response = await Mediator.Send(new GetSecondaryAccountByIdQuery(Id));

      return Ok(response);
    }


    [HttpGet(Router.AccountRouter.GetPrimaryAccountById)]
    public async Task<IActionResult> GetPrimaryAccountById(int Id)
    {
      var response = await Mediator.Send(new GetPrimaryAccountByIdQuery(Id));

      return NewResult(response);
    }


    //if you dont need parent id you must send null
    [HttpPost(Router.AccountRouter.Create)]
    //[Authorize(Policy = "CreateAccount")]
    public async Task<IActionResult> CreateAccount([FromBody] AddAccountCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }





    [HttpPut(Router.AccountRouter.Edit)]
    public async Task<IActionResult> EditAccount([FromBody] EditAccountCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.AccountRouter.Delete)]
    public async Task<IActionResult> DeleteAccountById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteAccountCommand(Id));

      return NewResult(response);
    }

  }
}
