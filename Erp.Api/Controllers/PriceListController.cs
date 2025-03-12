using Erp.Core.Features.PriceList.Commands.Models;
using Erp.Core.Features.PriceList.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PriceListController : AppControllerBase

  {
    public PriceListController(IWebHostEnvironment webHostEnvironment)
    {
      _webHost = webHostEnvironment;
    }




    [HttpPost(Router.PriceListRouter.Create)]
    //[Authorize(Policy = "CreatePriceList")]
    public async Task<IActionResult> CreatePriceList([FromForm] AddPriceListCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }

    [HttpPost(Router.PriceListRouter.AddItems)]
    //[Authorize(Policy = "CreatePriceList")]
    public async Task<IActionResult> AddPriceListItem([FromForm] AddPriceListItemCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpGet(Router.PriceListRouter.GetList)]
    public async Task<IActionResult> GetPriceListList()
    {
      var response = await Mediator.Send(new GetPriceListListQuery());

      return Ok(response);
    }


    [HttpGet(Router.PriceListRouter.GetById)]
    public async Task<IActionResult> GetPriceListById(int Id)
    {
      var response = await Mediator.Send(new GetPriceListByIdQuery(Id));

      return NewResult(response);
    }



    [HttpPut(Router.PriceListRouter.Edit)]
    public async Task<IActionResult> EditPriceList([FromBody] EditPriceListCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.PriceListRouter.Delete)]
    public async Task<IActionResult> DeletePriceListById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeletePriceListCommand(Id));

      return NewResult(response);
    }
  }
}
