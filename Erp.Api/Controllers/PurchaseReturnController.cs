using Erp.Core.Features.PurchaseReturn.Commands.Models;
using Erp.Core.Features.PurchaseReturn.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PurchaseReturnController : AppControllerBase
  {


    [HttpPost(Router.PurchaseReturnRouter.Create)]
    //[Authorize(Policy = "CreateProduct")]
    public async Task<IActionResult> CreatePurchaseReturn([FromBody] AddPurchaseReturnCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }

    [HttpGet(Router.PurchaseReturnRouter.GetList)]
    public async Task<IActionResult> GetPurchaseReturnList()
    {
      var response = await Mediator.Send(new GetPurchaseReturnListQuery());

      return Ok(response);
    }


    [HttpGet(Router.PurchaseReturnRouter.GetById)]
    public async Task<IActionResult> GetPurchaseReturnById(int Id)
    {
      var response = await Mediator.Send(new GetPurchaseReturnByIdQuery(Id));

      return NewResult(response);
    }

    [HttpPut(Router.PurchaseReturnRouter.Edit)]
    public async Task<IActionResult> EditPurchaseReturn([FromBody] EditPurchaseReturnCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.PurchaseReturnRouter.Delete)]
    public async Task<IActionResult> DeletePurchaseReturnById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeletePurchaseReturnCommand(Id));

      return NewResult(response);
    }


  }
}
