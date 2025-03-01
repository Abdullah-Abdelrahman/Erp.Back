using Erp.Core.Features.Company.Commands.Models;
using Erp.Core.Features.Company.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CompanyController : AppControllerBase
  {

    public CompanyController(IWebHostEnvironment webHostEnvironment)
    {
      _webHost = webHostEnvironment;
    }

    [HttpGet(Router.CompanyRouter.GetList)]
    public async Task<IActionResult> GetCompanysList()
    {
      var response = await Mediator.Send(new GetCompanyListQuery());

      return Ok(response);
    }


    [HttpGet(Router.CompanyRouter.GetById)]
    public async Task<IActionResult> GetCompanyById(int Id)
    {
      var response = await Mediator.Send(new GetCompanyByIdQuery(Id));

      return NewResult(response);
    }


    [HttpPost(Router.CompanyRouter.Create)]
    //[Authorize(Policy = "CreateCompany")]
    public async Task<IActionResult> CreateCompany([FromForm] AddCompanyCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }





    [HttpPut(Router.CompanyRouter.Edit)]
    public async Task<IActionResult> EditCompany([FromBody] EditCompanyCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.CompanyRouter.Delete)]
    public async Task<IActionResult> DeleteCompanyById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteCompanyCommand(Id));

      return NewResult(response);
    }

  }
}
