using Erp.Core.Features.Customer.Commands.Models;
using Erp.Core.Features.Customer.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomerController : AppControllerBase
  {

    public CustomerController(IWebHostEnvironment webHostEnvironment)
    {
      _webHost = webHostEnvironment;
    }


    [HttpGet(Router.CustomerRouter.GetCustomerList)]
    public async Task<IActionResult> GetCustomerList()
    {
      var response = await Mediator.Send(new GetCustomerListQuery());

      return Ok(response);
    }


    [HttpGet(Router.CustomerRouter.GetCustomerTypeById)]
    public async Task<IActionResult> GetCustomerTypeById(int Id)
    {
      var response = await Mediator.Send(new GetCustomerTypeByIdQuery(Id));

      return NewResult(response);
    }

    [HttpGet(Router.CustomerRouter.GetIndividualCustomerById)]
    public async Task<IActionResult> GetIndividualCustomerByIdQuery(int Id)
    {
      var response = await Mediator.Send(new GetIndividualCustomerByIdQuery(Id));

      return Ok(response);
    }


    [HttpGet(Router.CustomerRouter.GetCommercialCustomerById)]
    public async Task<IActionResult> GetCommercialCustomerById(int Id)
    {
      var response = await Mediator.Send(new GetCommercialCustomerByIdQuery(Id));

      return NewResult(response);
    }


    //if you dont need parent id you must send null
    [HttpPost(Router.CustomerRouter.Create)]
    //[Authorize(Policy = "CreateCustomer")]
    public async Task<IActionResult> CreateCustomer([FromBody] AddCustomerCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }





    [HttpPut(Router.CustomerRouter.Edit)]
    public async Task<IActionResult> EditCustomer([FromBody] EditCustomerCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.CustomerRouter.Delete)]
    public async Task<IActionResult> DeleteCustomerById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteCustomerCommand(Id));

      return NewResult(response);
    }

  }
}
