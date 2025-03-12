using Erp.Core.Features.CompanyModule.Commands.Models;
using Erp.Core.Features.CompanyModule.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CompanyModuleController : AppControllerBase

  {
    public CompanyModuleController(IWebHostEnvironment webHostEnvironment)
    {
      _webHost = webHostEnvironment;
    }




    [HttpPut(Router.CompanyModuleRouter.ActivateModule)]
    //[Authorize(Policy = "CreateCompanyModule")]
    public async Task<IActionResult> CreateCompanyModule([FromRoute] int Id)
    {
      var response = await Mediator.Send(new ActivateModuleCommand(Id));

      return NewResult(response);

    }

    [HttpGet(Router.CompanyModuleRouter.GetActiveModulesList)]
    public async Task<IActionResult> GetActiveModulesList()
    {
      var response = await Mediator.Send(new GetActiveModulesListQuery());

      return Ok(response);
    }







    [HttpPut(Router.CompanyModuleRouter.DeActivateModule)]
    public async Task<IActionResult> DeActivateModuleById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeActivateModuleCommand(Id));

      return NewResult(response);
    }
  }
}

