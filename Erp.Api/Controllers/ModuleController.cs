using Erp.Core.Features.Module.Commands.Models;
using Erp.Core.Features.Module.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ModuleController : AppControllerBase

  {
    public ModuleController(IWebHostEnvironment webHostEnvironment)
    {
      _webHost = webHostEnvironment;
    }




    [HttpPost(Router.ModuleRouter.Create)]
    //[Authorize(Policy = "CreateModule")]
    public async Task<IActionResult> CreateModule([FromBody] AddModuleCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }
    [HttpGet(Router.ModuleRouter.GetList)]
    public async Task<IActionResult> GetModuleList()
    {
      var response = await Mediator.Send(new GetModuleListQuery());

      return Ok(response);
    }


    [HttpGet(Router.ModuleRouter.GetById)]
    public async Task<IActionResult> GetModuleById(int Id)
    {
      var response = await Mediator.Send(new GetModuleByIdQuery(Id));

      return NewResult(response);
    }



    [HttpPut(Router.ModuleRouter.Edit)]
    public async Task<IActionResult> EditModule([FromBody] EditModuleCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.ModuleRouter.Delete)]
    public async Task<IActionResult> DeleteModuleById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteModuleCommand(Id));

      return NewResult(response);
    }
  }
}
