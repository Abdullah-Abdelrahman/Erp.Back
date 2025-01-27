
using Erp.Core.Features.Supplier.Commands.Models;
using Erp.Core.Features.Supplier.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SupplierController : AppControllerBase
  {

    public SupplierController(IWebHostEnvironment webHostEnvironment)
    {
      _webHost = webHostEnvironment;
    }

    [HttpGet(Router.SupplierRouter.GetList)]
    public async Task<IActionResult> GetSuppliersList()
    {
      var response = await Mediator.Send(new GetSupplierListQuery());

      return Ok(response);
    }


    [HttpGet(Router.SupplierRouter.GetById)]
    public async Task<IActionResult> GetSupplierById(int Id)
    {
      var response = await Mediator.Send(new GetSupplierByIdQuery(Id));

      return NewResult(response);
    }


    [HttpPost(Router.SupplierRouter.Create)]
    //[Authorize(Policy = "CreateSupplier")]
    public async Task<IActionResult> CreateSupplier([FromForm] AddSupplierCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }





    [HttpPut(Router.SupplierRouter.Edit)]
    public async Task<IActionResult> EditSupplier([FromBody] EditSupplierCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.SupplierRouter.Delete)]
    public async Task<IActionResult> DeleteSupplierById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteSupplierCommand(Id));

      return NewResult(response);
    }

  }
}
