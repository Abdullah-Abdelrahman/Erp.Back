using Erp.Core.Features.ContactList.Commands.Models;
using Erp.Core.Features.ContactList.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ContactListController : AppControllerBase
  {

    public ContactListController(IWebHostEnvironment webHostEnvironment)
    {
      _webHost = webHostEnvironment;
    }

    [HttpGet(Router.ContactListRouter.GetList)]
    public async Task<IActionResult> GetContactListsList()
    {
      var response = await Mediator.Send(new GetContactListListQuery());

      return Ok(response);
    }


    [HttpGet(Router.ContactListRouter.GetById)]
    public async Task<IActionResult> GetContactListById(int Id)
    {
      var response = await Mediator.Send(new GetContactListByIdQuery(Id));

      return NewResult(response);
    }


    [HttpPost(Router.ContactListRouter.Create)]
    //[Authorize(Policy = "CreateContactList")]
    public async Task<IActionResult> CreateContactList([FromForm] AddContactListCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }





    [HttpPut(Router.ContactListRouter.Edit)]
    public async Task<IActionResult> EditContactList([FromBody] EditContactListCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.ContactListRouter.Delete)]
    public async Task<IActionResult> DeleteContactListById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteContactListCommand(Id));

      return NewResult(response);
    }

  }
}
