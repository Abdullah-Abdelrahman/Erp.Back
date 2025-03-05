using Erp.Core.Features.ProductAndService.Commands.Models;
using Erp.Core.Features.ProductAndService.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductAndServiceController : AppControllerBase
  {

    public ProductAndServiceController(IWebHostEnvironment webHostEnvironment)
    {
      _webHost = webHostEnvironment;
    }

    [HttpGet(Router.ProductAndServiceRouter.GetProductsServicesPaginated)]
    public async Task<IActionResult> GetProductsServicesPaginated([FromQuery] GetProductAndServicePaginatedListQuery request)
    {
      var response = await Mediator.Send(request);

      return Ok(response);
    }

    [HttpGet(Router.ServiceRouter.GetList)]
    public async Task<IActionResult> GetServicesList()
    {
      var response = await Mediator.Send(new GetServiceListQuery());

      return Ok(response);
    }


    [HttpGet(Router.ServiceRouter.GetById)]
    public async Task<IActionResult> GetServiceById(int Id)
    {
      var response = await Mediator.Send(new GetServiceByIdQuery(Id));

      return NewResult(response);
    }


    [HttpPost(Router.ServiceRouter.Create)]
    //[Authorize(Policy = "CreateProduct")]
    public async Task<IActionResult> CreateService([FromForm] AddServiceCommand command)
    {
      command.WebRootPath = _webHost.ContentRootPath;
      var response = await Mediator.Send(command);

      return NewResult(response);
    }





    [HttpPut(Router.ServiceRouter.Edit)]
    public async Task<IActionResult> EditService([FromBody] EditServiceCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.ServiceRouter.Delete)]
    public async Task<IActionResult> DeleteServiceById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteServiceCommand(Id));

      return NewResult(response);
    }

  }
}
