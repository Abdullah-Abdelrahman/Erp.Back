using Erp.Core.Features.DeliveryVoucher.Commands.Models;
using Erp.Core.Features.DeliveryVoucher.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/Inventory/[controller]")]
  [ApiController]
  public class DeliveryVoucherController : AppControllerBase
  {


    [HttpPost(Router.DeliveryVoucherRouter.Create)]
    //[Authorize(Policy = "CreateProduct")]
    public async Task<IActionResult> CreateDeliveryVoucher([FromBody] AddDeliveryVoucherCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }

    [HttpGet(Router.DeliveryVoucherRouter.GetList)]
    public async Task<IActionResult> GetDeliveryVoucherList()
    {
      var response = await Mediator.Send(new GetDeliveryVoucherListQuery());

      return Ok(response);
    }


    [HttpGet(Router.DeliveryVoucherRouter.GetById)]
    public async Task<IActionResult> GetDeliveryVoucherById(int Id)
    {
      var response = await Mediator.Send(new GetDeliveryVoucherByIdQuery(Id));

      return NewResult(response);
    }

    [HttpPut(Router.DeliveryVoucherRouter.Edit)]
    public async Task<IActionResult> EditDeliveryVoucher([FromBody] EditDeliveryVoucherCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.DeliveryVoucherRouter.Delete)]
    public async Task<IActionResult> DeleteDeliveryVoucherById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteDeliveryVoucherCommand(Id));

      return NewResult(response);
    }


    [HttpPut(Router.DeliveryVoucherRouter.Confirm)]
    public async Task<IActionResult> ConfirmDeliveryVoucherById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new ConfirmDeliveryVoucherCommand(Id));

      return NewResult(response);
    }


    [HttpPut(Router.DeliveryVoucherRouter.Reject)]
    public async Task<IActionResult> RejectDeliveryVoucherById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new RejectDeliveryVoucherCommand(Id));

      return NewResult(response);
    }
  }
}
