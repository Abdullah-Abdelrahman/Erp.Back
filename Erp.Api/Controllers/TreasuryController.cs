using Erp.Core.Features.Treasury.Commands.Models;
using Erp.Core.Features.Treasury.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TreasuryController : AppControllerBase
  {


    [HttpPost(Router.TreasuryRouter.Create)]
    //[Authorize(Policy = "CreateProduct")]
    public async Task<IActionResult> CreateTreasury([FromBody] AddTreasuryCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }

    [HttpGet(Router.TreasuryRouter.GetList)]
    public async Task<IActionResult> GetTreasuryList()
    {
      var response = await Mediator.Send(new GetTreasuryListQuery());

      return Ok(response);
    }


    [HttpGet(Router.TreasuryRouter.GetById)]
    public async Task<IActionResult> GetTreasuryById(int Id)
    {
      var response = await Mediator.Send(new GetTreasuryByIdQuery(Id));

      return NewResult(response);
    }

    [HttpPut(Router.TreasuryRouter.Edit)]
    public async Task<IActionResult> EditTreasury([FromBody] EditTreasuryCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.TreasuryRouter.Delete)]
    public async Task<IActionResult> DeleteTreasuryById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteTreasuryCommand(Id));

      return NewResult(response);
    }


  }
}
