using Erp.Core.Features.CostCenter.Commands.Models;
using Erp.Core.Features.CostCenter.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CostCenterController : AppControllerBase
  {

    public CostCenterController(IWebHostEnvironment webHostEnvironment)
    {
      _webHost = webHostEnvironment;
    }

    [HttpGet(Router.CostCenterRouter.GetMainCostCentersList)]
    public async Task<IActionResult> GetMainCostCentersList()
    {
      var response = await Mediator.Send(new GetMainCostCentersListQuery());

      return Ok(response);
    }


    [HttpGet(Router.CostCenterRouter.GetCostCenterTypeById)]
    public async Task<IActionResult> GetCostCenterTypeById(int Id)
    {
      var response = await Mediator.Send(new GetCostCenterTypeByIdQuery(Id));

      return NewResult(response);
    }

    [HttpGet(Router.CostCenterRouter.GetSecondaryCostCenterById)]
    public async Task<IActionResult> GetSecondaryCostCenterByIdQuery(int Id)
    {
      var response = await Mediator.Send(new GetSecondaryCostCenterByIdQuery(Id));

      return Ok(response);
    }


    [HttpGet(Router.CostCenterRouter.GetPrimaryCostCenterById)]
    public async Task<IActionResult> GetPrimaryCostCenterById(int Id)
    {
      var response = await Mediator.Send(new GetPrimaryCostCenterByIdQuery(Id));

      return NewResult(response);
    }
    [HttpGet(Router.CostCenterRouter.GetPrimaryCostCenterList)]
    public async Task<IActionResult> GetCostCentersList()
    {
      var response = await Mediator.Send(new GetPrimaryCostCentersListQuery());

      return Ok(response);
    }

    [HttpGet(Router.CostCenterRouter.GetSecondaryCostCenterList)]
    public async Task<IActionResult> GetSecondaryCostCentersList()
    {
      var response = await Mediator.Send(new GetSecondaryCostCentersListQuery());

      return Ok(response);
    }

    //if you dont need parent id you must send null
    [HttpPost(Router.CostCenterRouter.Create)]
    //[Authorize(Policy = "CreateCostCenter")]
    public async Task<IActionResult> CreateCostCenter([FromBody] AddCostCenterCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }





    [HttpPut(Router.CostCenterRouter.Edit)]
    public async Task<IActionResult> EditCostCenter([FromBody] EditCostCenterCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.CostCenterRouter.Delete)]
    public async Task<IActionResult> DeleteCostCenterById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteCostCenterCommand(Id));

      return NewResult(response);
    }

  }
}
