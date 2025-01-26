using Erp.Core.Features.DebitNote.Commands.Models;
using Erp.Core.Features.DebitNote.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DebitNoteController : AppControllerBase
  {


    [HttpPost(Router.DebitNoteRouter.Create)]
    //[Authorize(Policy = "CreateProduct")]
    public async Task<IActionResult> CreateDebitNote([FromBody] AddDebitNoteCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }

    [HttpGet(Router.DebitNoteRouter.GetList)]
    public async Task<IActionResult> GetDebitNoteList()
    {
      var response = await Mediator.Send(new GetDebitNoteListQuery());

      return Ok(response);
    }


    [HttpGet(Router.DebitNoteRouter.GetById)]
    public async Task<IActionResult> GetDebitNoteById(int Id)
    {
      var response = await Mediator.Send(new GetDebitNoteByIdQuery(Id));

      return NewResult(response);
    }

    [HttpPut(Router.DebitNoteRouter.Edit)]
    public async Task<IActionResult> EditDebitNote([FromBody] EditDebitNoteCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.DebitNoteRouter.Delete)]
    public async Task<IActionResult> DeleteDebitNoteById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteDebitNoteCommand(Id));

      return NewResult(response);
    }


  }
}
