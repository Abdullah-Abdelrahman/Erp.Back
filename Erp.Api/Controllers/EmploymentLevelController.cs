using Erp.Core.Features.EmploymentLevel.Commands.Models;
using Erp.Core.Features.EmploymentLevel.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmploymentLevelController : AppControllerBase

  {
    public EmploymentLevelController(IWebHostEnvironment webHostEnvironment)
    {
      _webHost = webHostEnvironment;
    }




    [HttpPost(Router.EmploymentLevelRouter.Create)]
    //[Authorize(Policy = "CreateEmploymentLevel")]
    public async Task<IActionResult> CreateEmploymentLevel([FromBody] AddEmploymentLevelCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }
    [HttpGet(Router.EmploymentLevelRouter.GetList)]
    public async Task<IActionResult> GetEmploymentLevelList()
    {
      var response = await Mediator.Send(new GetEmploymentLevelListQuery());

      return Ok(response);
    }


    [HttpGet(Router.EmploymentLevelRouter.GetById)]
    public async Task<IActionResult> GetEmploymentLevelById(int Id)
    {
      var response = await Mediator.Send(new GetEmploymentLevelByIdQuery(Id));

      return NewResult(response);
    }



    [HttpPut(Router.EmploymentLevelRouter.Edit)]
    public async Task<IActionResult> EditEmploymentLevel([FromBody] EditEmploymentLevelCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.EmploymentLevelRouter.Delete)]
    public async Task<IActionResult> DeleteEmploymentLevelById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteEmploymentLevelCommand(Id));

      return NewResult(response);
    }
  }
}


