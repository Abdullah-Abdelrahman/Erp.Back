using Erp.Core.Features.ReceiptCategory.Commands.Models;
using Erp.Core.Features.ReceiptCategory.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ReceiptCategoryController : AppControllerBase

  {
    public ReceiptCategoryController(IWebHostEnvironment webHostEnvironment)
    {
      _webHost = webHostEnvironment;
    }




    [HttpPost(Router.ReceiptCategoryRouter.Create)]
    //[Authorize(Policy = "CreateReceiptCategory")]
    public async Task<IActionResult> CreateReceiptCategory([FromBody] AddReceiptCategoryCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }
    [HttpGet(Router.ReceiptCategoryRouter.GetList)]
    public async Task<IActionResult> GetReceiptCategoryList()
    {
      var response = await Mediator.Send(new GetReceiptCategoryListQuery());

      return Ok(response);
    }


    [HttpGet(Router.ReceiptCategoryRouter.GetById)]
    public async Task<IActionResult> GetReceiptCategoryById(int Id)
    {
      var response = await Mediator.Send(new GetReceiptCategoryByIdQuery(Id));

      return NewResult(response);
    }



    [HttpPut(Router.ReceiptCategoryRouter.Edit)]
    public async Task<IActionResult> EditReceiptCategory([FromBody] EditReceiptCategoryCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.ReceiptCategoryRouter.Delete)]
    public async Task<IActionResult> DeleteReceiptCategoryById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteReceiptCategoryCommand(Id));

      return NewResult(response);
    }
  }
}

