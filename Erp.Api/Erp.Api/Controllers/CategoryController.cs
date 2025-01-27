using Erp.Core.Features.Category.Commands.Models;
using Erp.Core.Features.Category.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CategoryController : AppControllerBase

  {
    public CategoryController(IWebHostEnvironment webHostEnvironment)
    {
      _webHost = webHostEnvironment;
    }




    [HttpPost(Router.CategoryRouter.Create)]
    //[Authorize(Policy = "CreateCategory")]
    public async Task<IActionResult> CreateCategory([FromForm] AddCategoryCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }
    [HttpGet(Router.CategoryRouter.GetList)]
    public async Task<IActionResult> GetCategoryList()
    {
      var response = await Mediator.Send(new GetCategoryListQuery());

      return Ok(response);
    }


    [HttpGet(Router.CategoryRouter.GetById)]
    public async Task<IActionResult> GetCategoryById(int Id)
    {
      var response = await Mediator.Send(new GetCategoryByIdQuery(Id));

      return NewResult(response);
    }



    [HttpPut(Router.CategoryRouter.Edit)]
    public async Task<IActionResult> EditCategory([FromBody] EditCategoryCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.CategoryRouter.Delete)]
    public async Task<IActionResult> DeleteCategoryById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteCategoryCommand(Id));

      return NewResult(response);
    }
  }
}
