using Erp.Core.Features.CreditNote.Commands.Models;
using Erp.Core.Features.CreditNote.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CreditNoteController : AppControllerBase
  {


    [HttpPost(Router.CreditNoteRouter.Create)]
    //[Authorize(Policy = "CreateProduct")]
    public async Task<IActionResult> CreateCreditNote([FromBody] AddCreditNoteCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }

    [HttpGet(Router.CreditNoteRouter.GetList)]
    public async Task<IActionResult> GetCreditNoteList()
    {
      var response = await Mediator.Send(new GetCreditNoteListQuery());

      return Ok(response);
    }


    [HttpGet(Router.CreditNoteRouter.GetById)]
    public async Task<IActionResult> GetCreditNoteById(int Id)
    {
      var response = await Mediator.Send(new GetCreditNoteByIdQuery(Id));

      return NewResult(response);
    }

    [HttpPut(Router.CreditNoteRouter.Edit)]
    public async Task<IActionResult> EditCreditNote([FromBody] EditCreditNoteCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.CreditNoteRouter.Delete)]
    public async Task<IActionResult> DeleteCreditNoteById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteCreditNoteCommand(Id));

      return NewResult(response);
    }


  }
}
