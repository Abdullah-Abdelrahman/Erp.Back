using Erp.Core.Features.Employee.Commands.Models;
using Erp.Core.Features.Employee.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeeController : AppControllerBase
  {

    public EmployeeController(IWebHostEnvironment webHostEnvironment)
    {
      _webHost = webHostEnvironment;
    }


    [HttpGet(Router.EmployeeRouter.GetList)]
    public async Task<IActionResult> GetEmployeeList()
    {
      var response = await Mediator.Send(new GetEmployeeListQuery());

      return Ok(response);
    }




    [HttpGet(Router.EmployeeRouter.GetById)]
    public async Task<IActionResult> GetIndividualEmployeeByIdQuery(int Id)
    {
      var response = await Mediator.Send(new GetEmployeeByIdQuery(Id));

      return Ok(response);
    }



    //if you dont need parent id you must send null
    [HttpPost(Router.EmployeeRouter.Create)]
    //[Authorize(Policy = "CreateEmployee")]
    public async Task<IActionResult> CreateEmployee([FromForm] AddEmployeeCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }





    [HttpPut(Router.EmployeeRouter.Edit)]
    public async Task<IActionResult> EditEmployee([FromForm] EditEmployeeCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.EmployeeRouter.Delete)]
    public async Task<IActionResult> DeleteEmployeeById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteEmployeeCommand(Id));

      return NewResult(response);
    }

  }
}
