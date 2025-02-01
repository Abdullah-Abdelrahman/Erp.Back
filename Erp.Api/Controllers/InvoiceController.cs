using Erp.Core.Features.Invoice.Commands.Models;
using Erp.Core.Features.Invoice.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class InvoiceController : AppControllerBase
  {


    [HttpPost(Router.InvoiceRouter.Create)]
    //[Authorize(Policy = "CreateProduct")]
    public async Task<IActionResult> CreateInvoice([FromBody] AddInvoiceCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }

    [HttpGet(Router.InvoiceRouter.GetList)]
    public async Task<IActionResult> GetInvoiceList()
    {
      var response = await Mediator.Send(new GetInvoiceListQuery());

      return Ok(response);
    }


    [HttpGet(Router.InvoiceRouter.GetById)]
    public async Task<IActionResult> GetInvoiceById(int Id)
    {
      var response = await Mediator.Send(new GetInvoiceByIdQuery(Id));

      return NewResult(response);
    }

    [HttpPut(Router.InvoiceRouter.Edit)]
    public async Task<IActionResult> EditInvoice([FromBody] EditInvoiceCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.InvoiceRouter.Delete)]
    public async Task<IActionResult> DeleteInvoiceById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteInvoiceCommand(Id));

      return NewResult(response);
    }


  }
}
