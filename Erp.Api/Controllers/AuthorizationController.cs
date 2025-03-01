using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Core.Features.Authorization.Commands.Models;
using Name.Core.Features.Authorization.Quaries.Models;
using Name.Data.MetaData;

namespace Name.Api.Controllers
{
  [Route("api/[controller]")]

  [ApiController]
  public class AuthorizationController : AppControllerBase
  {

    #region crud on role

    [HttpPost(Router.AuthorizationRouter.Create)]
    public async Task<IActionResult> CreateRole([FromForm] AddRoleCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpGet(Router.AuthorizationRouter.GetList)]
    public async Task<IActionResult> GetRoleList()
    {
      var response = await Mediator.Send(new GetRoleListQuery());

      return Ok(response);
    }

    [HttpGet(Router.AuthorizationRouter.GetById)]
    public async Task<IActionResult> GetRoleById(string Id)
    {
      var response = await Mediator.Send(new GetRoleByIdQuery(Id));

      return NewResult(response);
    }

    [HttpPut(Router.AuthorizationRouter.Edit)]
    public async Task<IActionResult> EditAnswer([FromForm] EditRoleCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.AuthorizationRouter.Delete)]
    public async Task<IActionResult> DeleteRoleById([FromRoute] string Id)
    {
      var response = await Mediator.Send(new DeleteRoleCommand(Id));

      return NewResult(response);
    }
    #endregion



    [HttpGet(Router.AuthorizationRouter.ManageUserRoles)]
    public async Task<IActionResult> ManageUserRoles([FromRoute] string Id)
    {
      var response = await Mediator.Send(new ManageUserRolesQuery(Id));

      return Ok(response);
    }



    [HttpPost(Router.AuthorizationRouter.UpdateUserRoles)]
    public async Task<IActionResult> UpdateUserRoles([FromBody] UpdateUserRolesCommand request)
    {
      var response = await Mediator.Send(request);

      return Ok(response);
    }


    [HttpGet(Router.AuthorizationRouter.ManageUserClaims)]
    public async Task<IActionResult> ManageUserClaims([FromRoute] string Id)
    {
      var response = await Mediator.
          Send(new ManageUserClaimsQuery(Id));
      return NewResult(response);
    }


    [HttpPut(Router.AuthorizationRouter.UpdateUserClaims)]
    public async Task<IActionResult> UpdateUserClaims([FromBody] UpdateUserClaimsCommand command)
    {
      var response = await Mediator.Send(command);
      return NewResult(response);
    }








  }
}
