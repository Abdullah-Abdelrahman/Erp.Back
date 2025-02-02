using Erp.Core.Features.RecurringInvoice.Commands.Models;
using Erp.Core.Features.RecurringInvoice.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RecurringInvoiceController : AppControllerBase
  {


    [HttpPost(Router.RecurringInvoiceRouter.Create)]
    //[Authorize(Policy = "CreateProduct")]
    public async Task<IActionResult> CreateRecurringInvoice([FromBody] AddRecurringInvoiceCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }

    [HttpGet(Router.RecurringInvoiceRouter.GetList)]
    public async Task<IActionResult> GetRecurringInvoiceList()
    {
      var response = await Mediator.Send(new GetRecurringInvoiceListQuery());

      return Ok(response);
    }


    [HttpGet(Router.RecurringInvoiceRouter.GetById)]
    public async Task<IActionResult> GetRecurringInvoiceById(int Id)
    {
      var response = await Mediator.Send(new GetRecurringInvoiceByIdQuery(Id));

      return NewResult(response);
    }

    [HttpPut(Router.RecurringInvoiceRouter.Edit)]
    public async Task<IActionResult> EditRecurringInvoice([FromBody] EditRecurringInvoiceCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.RecurringInvoiceRouter.Delete)]
    public async Task<IActionResult> DeleteRecurringInvoiceById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteRecurringInvoiceCommand(Id));

      return NewResult(response);
    }


  }
}
