using Erp.Core.Features.Warehouses.Commands.Models;
using Erp.Core.Features.Warehouses.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/Inventory/[controller]")]
  [ApiController]
  public class WarehouseController : AppControllerBase
  {


    [HttpGet(Router.WarehouseRouter.GetList)]
    public async Task<IActionResult> GetWarehouseList()
    {
      var response = await Mediator.Send(new GetWarehouseListQuery());

      return Ok(response);
    }


    [HttpGet(Router.WarehouseRouter.GetById)]
    public async Task<IActionResult> GetWarehouseById(int Id)
    {
      var response = await Mediator.Send(new GetWarehouseByIdQuery(Id));

      return NewResult(response);
    }


    [HttpPost(Router.WarehouseRouter.Create)]
    //[Authorize(Policy = "CreateProduct")]
    public async Task<IActionResult> CreateWarehouse([FromForm] AddWarehouseCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }





    [HttpPut(Router.WarehouseRouter.Edit)]
    public async Task<IActionResult> EditWarehouse([FromBody] EditWarehouseCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.WarehouseRouter.Delete)]
    public async Task<IActionResult> DeleteWarehouseById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteWarehouseCommand(Id));

      return NewResult(response);
    }
  }
}
