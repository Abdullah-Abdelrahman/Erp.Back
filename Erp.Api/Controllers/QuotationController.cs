using Erp.Core.Features.Quotation.Commands.Models;
using Erp.Core.Features.Quotation.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class QuotationController : AppControllerBase
  {


    [HttpPost(Router.QuotationRouter.Create)]
    //[Authorize(Policy = "CreateProduct")]
    public async Task<IActionResult> CreateQuotation([FromBody] AddQuotationCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }

    [HttpGet(Router.QuotationRouter.GetList)]
    public async Task<IActionResult> GetQuotationList()
    {
      var response = await Mediator.Send(new GetQuotationListQuery());

      return Ok(response);
    }


    [HttpGet(Router.QuotationRouter.GetById)]
    public async Task<IActionResult> GetQuotationById(int Id)
    {
      var response = await Mediator.Send(new GetQuotationByIdQuery(Id));

      return NewResult(response);
    }

    [HttpPut(Router.QuotationRouter.Edit)]
    public async Task<IActionResult> EditQuotation([FromBody] EditQuotationCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.QuotationRouter.Delete)]
    public async Task<IActionResult> DeleteQuotationById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteQuotationCommand(Id));

      return NewResult(response);
    }


  }
}
