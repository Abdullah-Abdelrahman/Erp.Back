using Erp.Core.Features.Department.Commands.Models;
using Erp.Core.Features.Department.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DepartmentController : AppControllerBase

  {
    public DepartmentController(IWebHostEnvironment webHostEnvironment)
    {
      _webHost = webHostEnvironment;
    }




    [HttpPost(Router.DepartmentRouter.Create)]
    //[Authorize(Policy = "CreateDepartment")]
    public async Task<IActionResult> CreateDepartment([FromBody] AddDepartmentCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }
    [HttpGet(Router.DepartmentRouter.GetList)]
    public async Task<IActionResult> GetDepartmentList()
    {
      var response = await Mediator.Send(new GetDepartmentListQuery());

      return Ok(response);
    }


    [HttpGet(Router.DepartmentRouter.GetById)]
    public async Task<IActionResult> GetDepartmentById(int Id)
    {
      var response = await Mediator.Send(new GetDepartmentByIdQuery(Id));

      return NewResult(response);
    }



    [HttpPut(Router.DepartmentRouter.Edit)]
    public async Task<IActionResult> EditDepartment([FromBody] EditDepartmentCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.DepartmentRouter.Delete)]
    public async Task<IActionResult> DeleteDepartmentById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteDepartmentCommand(Id));

      return NewResult(response);
    }
  }
}

