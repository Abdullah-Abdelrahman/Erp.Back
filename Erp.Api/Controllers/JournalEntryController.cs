using Erp.Core.Features.JournalEntry.Commands.Models;
using Erp.Core.Features.JournalEntry.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class JournalEntryController : AppControllerBase
  {


    [HttpPost(Router.JournalEntryRouter.Create)]
    //[Authorize(Policy = "CreateProduct")]
    public async Task<IActionResult> CreateJournalEntry([FromBody] AddJournalEntryCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }

    [HttpGet(Router.JournalEntryRouter.GetList)]
    public async Task<IActionResult> GetJournalEntryList()
    {
      var response = await Mediator.Send(new GetJournalEntryListQuery());

      return Ok(response);
    }


    [HttpGet(Router.JournalEntryRouter.GetById)]
    public async Task<IActionResult> GetJournalEntryById(int Id)
    {
      var response = await Mediator.Send(new GetJournalEntryByIdQuery(Id));

      return NewResult(response);
    }

    [HttpPut(Router.JournalEntryRouter.Edit)]
    public async Task<IActionResult> EditJournalEntry([FromBody] EditJournalEntryCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.JournalEntryRouter.Delete)]
    public async Task<IActionResult> DeleteJournalEntryById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteJournalEntryCommand(Id));

      return NewResult(response);
    }


  }
}
