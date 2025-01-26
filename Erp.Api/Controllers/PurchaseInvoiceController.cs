using Erp.Core.Features.PurchaseInvoice.Commands.Models;
using Erp.Core.Features.PurchaseInvoice.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PurchaseInvoiceController : AppControllerBase
  {


    [HttpPost(Router.PurchaseInvoiceRouter.Create)]
    //[Authorize(Policy = "CreateProduct")]
    public async Task<IActionResult> CreatePurchaseInvoice([FromBody] AddPurchaseInvoiceCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }

    [HttpGet(Router.PurchaseInvoiceRouter.GetList)]
    public async Task<IActionResult> GetPurchaseInvoiceList()
    {
      var response = await Mediator.Send(new GetPurchaseInvoiceListQuery());

      return Ok(response);
    }


    [HttpGet(Router.PurchaseInvoiceRouter.GetById)]
    public async Task<IActionResult> GetPurchaseInvoiceById(int Id)
    {
      var response = await Mediator.Send(new GetPurchaseInvoiceByIdQuery(Id));

      return NewResult(response);
    }

    [HttpPut(Router.PurchaseInvoiceRouter.Edit)]
    public async Task<IActionResult> EditPurchaseInvoice([FromBody] EditPurchaseInvoiceCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.PurchaseInvoiceRouter.Delete)]
    public async Task<IActionResult> DeletePurchaseInvoiceById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeletePurchaseInvoiceCommand(Id));

      return NewResult(response);
    }


  }
}
