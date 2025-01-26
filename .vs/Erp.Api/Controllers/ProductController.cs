
using Erp.Core.Features.Product.Commands.Models;
using Erp.Core.Features.Product.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductController : AppControllerBase
  {

    public ProductController(IWebHostEnvironment webHostEnvironment)
    {
      _webHost = webHostEnvironment;
    }

    [HttpGet(Router.ProductRouter.GetList)]
    public async Task<IActionResult> GetProductsList()
    {
      var response = await Mediator.Send(new GetProductListQuery());

      return Ok(response);
    }


    [HttpGet(Router.ProductRouter.GetById)]
    public async Task<IActionResult> GetProductById(int Id)
    {
      var response = await Mediator.Send(new GetProductByIdQuery(Id));

      return NewResult(response);
    }


    [HttpPost(Router.ProductRouter.Create)]
    //[Authorize(Policy = "CreateProduct")]
    public async Task<IActionResult> CreateProduct([FromForm] AddProductCommand command)
    {
      command.WebRootPath = _webHost.ContentRootPath;
      var response = await Mediator.Send(command);

      return NewResult(response);
    }





    [HttpPut(Router.ProductRouter.Edit)]
    public async Task<IActionResult> EditProduct([FromBody] EditProductCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.ProductRouter.Delete)]
    public async Task<IActionResult> DeleteProductById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteProductCommand(Id));

      return NewResult(response);
    }

  }
}
