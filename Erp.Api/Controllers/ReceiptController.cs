using Erp.Core.Features.Receipt.Commands.Models;
using Erp.Core.Features.Receipt.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ReceiptController : AppControllerBase
  {


    [HttpPost(Router.ReceiptRouter.Create)]
    //[Authorize(Policy = "CreateProduct")]
    public async Task<IActionResult> CreateReceipt([FromBody] AddReceiptCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }

    [HttpGet(Router.ReceiptRouter.GetList)]
    public async Task<IActionResult> GetReceiptList()
    {
      var response = await Mediator.Send(new GetReceiptListQuery());

      return Ok(response);
    }


    [HttpGet(Router.ReceiptRouter.GetById)]
    public async Task<IActionResult> GetReceiptById(int Id)
    {
      var response = await Mediator.Send(new GetReceiptByIdQuery(Id));

      return NewResult(response);
    }

    [HttpPut(Router.ReceiptRouter.Edit)]
    public async Task<IActionResult> EditReceipt([FromBody] EditReceiptCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.ReceiptRouter.Delete)]
    public async Task<IActionResult> DeleteReceiptById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteReceiptCommand(Id));

      return NewResult(response);
    }


  }
}
