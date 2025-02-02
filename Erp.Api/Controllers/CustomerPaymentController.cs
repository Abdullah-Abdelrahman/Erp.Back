using Erp.Core.Features.CustomerPayment.Commands.Models;
using Erp.Core.Features.CustomerPayment.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomerPaymentController : AppControllerBase
  {

    public CustomerPaymentController(IWebHostEnvironment webHostEnvironment)
    {
      _webHost = webHostEnvironment;
    }

    [HttpGet(Router.CustomerPaymentRouter.GetList)]
    public async Task<IActionResult> GetCustomerPaymentsList()
    {
      var response = await Mediator.Send(new GetCustomerPaymentListQuery());

      return Ok(response);
    }


    [HttpGet(Router.CustomerPaymentRouter.GetById)]
    public async Task<IActionResult> GetCustomerPaymentById(int Id)
    {
      var response = await Mediator.Send(new GetCustomerPaymentByIdQuery(Id));

      return NewResult(response);
    }


    [HttpPost(Router.CustomerPaymentRouter.Create)]
    //[Authorize(Policy = "CreateCustomerPayment")]
    public async Task<IActionResult> CreateCustomerPayment([FromForm] AddCustomerPaymentCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }





    [HttpPut(Router.CustomerPaymentRouter.Edit)]
    public async Task<IActionResult> EditCustomerPayment([FromBody] EditCustomerPaymentCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.CustomerPaymentRouter.Delete)]
    public async Task<IActionResult> DeleteCustomerPaymentById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteCustomerPaymentCommand(Id));

      return NewResult(response);
    }

  }
}
