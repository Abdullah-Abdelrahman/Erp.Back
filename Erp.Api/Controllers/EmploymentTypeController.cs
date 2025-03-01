using Erp.Core.Features.EmploymentType.Commands.Models;
using Erp.Core.Features.EmploymentType.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmploymentTypeController : AppControllerBase

  {
    public EmploymentTypeController(IWebHostEnvironment webHostEnvironment)
    {
      _webHost = webHostEnvironment;
    }




    [HttpPost(Router.EmploymentTypeRouter.Create)]
    //[Authorize(Policy = "CreateEmploymentType")]
    public async Task<IActionResult> CreateEmploymentType([FromBody] AddEmploymentTypeCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }
    [HttpGet(Router.EmploymentTypeRouter.GetList)]
    public async Task<IActionResult> GetEmploymentTypeList()
    {
      var response = await Mediator.Send(new GetEmploymentTypeListQuery());

      return Ok(response);
    }


    [HttpGet(Router.EmploymentTypeRouter.GetById)]
    public async Task<IActionResult> GetEmploymentTypeById(int Id)
    {
      var response = await Mediator.Send(new GetEmploymentTypeByIdQuery(Id));

      return NewResult(response);
    }



    [HttpPut(Router.EmploymentTypeRouter.Edit)]
    public async Task<IActionResult> EditEmploymentType([FromBody] EditEmploymentTypeCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.EmploymentTypeRouter.Delete)]
    public async Task<IActionResult> DeleteEmploymentTypeById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteEmploymentTypeCommand(Id));

      return NewResult(response);
    }
  }
}
