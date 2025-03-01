using Erp.Core.Features.JobType.Commands.Models;
using Erp.Core.Features.JobType.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class JobTypeController : AppControllerBase

  {
    public JobTypeController(IWebHostEnvironment webHostEnvironment)
    {
      _webHost = webHostEnvironment;
    }



    [HttpPost(Router.JobTypeRouter.Create)]
    //[Authorize(Policy = "CreateJobType")]
    public async Task<IActionResult> CreateJobType([FromBody] AddJobTypeCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }
    [HttpGet(Router.JobTypeRouter.GetList)]
    public async Task<IActionResult> GetJobTypeList()
    {
      var response = await Mediator.Send(new GetJobTypeListQuery());

      return Ok(response);
    }


    [HttpGet(Router.JobTypeRouter.GetById)]
    public async Task<IActionResult> GetJobTypeById(int Id)
    {
      var response = await Mediator.Send(new GetJobTypeByIdQuery(Id));

      return NewResult(response);
    }



    [HttpPut(Router.JobTypeRouter.Edit)]
    public async Task<IActionResult> EditJobType([FromBody] EditJobTypeCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.JobTypeRouter.Delete)]
    public async Task<IActionResult> DeleteJobTypeById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteJobTypeCommand(Id));

      return NewResult(response);
    }
  }
}
