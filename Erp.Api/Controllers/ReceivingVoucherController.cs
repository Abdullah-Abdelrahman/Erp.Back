using Erp.Core.Features.ReceivingVoucher.Commands.Models;
using Erp.Core.Features.ReceivingVoucher.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/Inventory/[controller]")]
  [ApiController]
  public class ReceivingVoucherController : AppControllerBase
  {


    [HttpPost(Router.ReceivingVoucherRouter.Create)]
    //[Authorize(Policy = "CreateProduct")]
    public async Task<IActionResult> CreateReceivingVoucher([FromBody] AddReceivingVoucherCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }

    [HttpGet(Router.ReceivingVoucherRouter.GetList)]
    public async Task<IActionResult> GetReceivingVoucherList()
    {
      var response = await Mediator.Send(new GetReceivingVoucherListQuery());

      return Ok(response);
    }


    [HttpGet(Router.ReceivingVoucherRouter.GetById)]
    public async Task<IActionResult> GetReceivingVoucherById(int Id)
    {
      var response = await Mediator.Send(new GetReceivingVoucherByIdQuery(Id));

      return NewResult(response);
    }

    [HttpPut(Router.ReceivingVoucherRouter.Edit)]
    public async Task<IActionResult> EditReceivingVoucher([FromBody] EditReceivingVoucherCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.ReceivingVoucherRouter.Delete)]
    public async Task<IActionResult> DeleteReceivingVoucherById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteReceivingVoucherCommand(Id));

      return NewResult(response);
    }


  }
}
