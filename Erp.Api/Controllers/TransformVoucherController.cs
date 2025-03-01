using Erp.Core.Features.TransformVoucher.Commands.Models;
using Erp.Core.Features.TransformVoucher.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/Inventory/[controller]")]
  [ApiController]
  public class TransformVoucherController : AppControllerBase
  {
    [HttpPost(Router.TransformVoucherRouter.Create)]
    //[Authorize(Policy = "CreateProduct")]
    public async Task<IActionResult> CreateTransformVoucher([FromBody] AddTransformVoucherCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }

    [HttpGet(Router.TransformVoucherRouter.GetList)]
    public async Task<IActionResult> GetTransformVoucherList()
    {
      var response = await Mediator.Send(new GetTransformVoucherListQuery());

      return Ok(response);
    }


    [HttpGet(Router.TransformVoucherRouter.GetById)]
    public async Task<IActionResult> GetTransformVoucherById(int Id)
    {
      var response = await Mediator.Send(new GetTransformVoucherByIdQuery(Id));

      return NewResult(response);
    }

    [HttpPut(Router.TransformVoucherRouter.Edit)]
    public async Task<IActionResult> EditTransformVoucher([FromBody] EditTransformVoucherCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.TransformVoucherRouter.Delete)]
    public async Task<IActionResult> DeleteTransformVoucherById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteTransformVoucherCommand(Id));

      return NewResult(response);
    }


  }
}
