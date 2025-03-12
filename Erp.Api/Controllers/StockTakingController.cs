using Erp.Core.Features.StockTaking.Commands.Models;
using Erp.Core.Features.StockTaking.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StockTakingController : AppControllerBase

  {
    public StockTakingController(IWebHostEnvironment webHostEnvironment)
    {
      _webHost = webHostEnvironment;
    }




    [HttpPost(Router.StockTakingRouter.Create)]
    //[Authorize(Policy = "CreateStockTaking")]
    public async Task<IActionResult> CreateStockTaking([FromBody] AddStockTakingCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }

    [HttpPost(Router.StockTakingRouter.AddItems)]
    //[Authorize(Policy = "CreateStockTaking")]
    public async Task<IActionResult> AddStockTakingItem([FromBody] AddStockTakingItemCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpGet(Router.StockTakingRouter.GetList)]
    public async Task<IActionResult> GetStockTakingList()
    {
      var response = await Mediator.Send(new GetStockTakingListQuery());

      return Ok(response);
    }


    [HttpGet(Router.StockTakingRouter.GetById)]
    public async Task<IActionResult> GetStockTakingById(int Id)
    {
      var response = await Mediator.Send(new GetStockTakingByIdQuery(Id));

      return NewResult(response);
    }


    [HttpPut(Router.StockTakingRouter.Settlement)]
    public async Task<IActionResult> SettlementStockTaking([FromBody] SettlementStockTakingCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpPut(Router.StockTakingRouter.Edit)]
    public async Task<IActionResult> EditStockTaking([FromBody] EditStockTakingCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.StockTakingRouter.Delete)]
    public async Task<IActionResult> DeleteStockTakingById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteStockTakingCommand(Id));

      return NewResult(response);
    }
  }
}
