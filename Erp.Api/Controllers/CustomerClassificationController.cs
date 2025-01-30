using Erp.Core.Features.CustomerClassification.Commands.Models;
using Erp.Core.Features.CustomerClassification.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomerClassificationController : AppControllerBase

  {
    public CustomerClassificationController(IWebHostEnvironment webHostEnvironment)
    {
      _webHost = webHostEnvironment;
    }




    [HttpPost(Router.CustomerClassificationRouter.Create)]
    //[Authorize(Policy = "CreateCustomerClassification")]
    public async Task<IActionResult> CreateCustomerClassification([FromForm] AddCustomerClassificationCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }
    [HttpGet(Router.CustomerClassificationRouter.GetList)]
    public async Task<IActionResult> GetCustomerClassificationList()
    {
      var response = await Mediator.Send(new GetCustomerClassificationListQuery());

      return Ok(response);
    }


    [HttpGet(Router.CustomerClassificationRouter.GetById)]
    public async Task<IActionResult> GetCustomerClassificationById(int Id)
    {
      var response = await Mediator.Send(new GetCustomerClassificationByIdQuery(Id));

      return NewResult(response);
    }



    [HttpPut(Router.CustomerClassificationRouter.Edit)]
    public async Task<IActionResult> EditCustomerClassification([FromBody] EditCustomerClassificationCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.CustomerClassificationRouter.Delete)]
    public async Task<IActionResult> DeleteCustomerClassificationById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteCustomerClassificationCommand(Id));

      return NewResult(response);
    }
  }
}
