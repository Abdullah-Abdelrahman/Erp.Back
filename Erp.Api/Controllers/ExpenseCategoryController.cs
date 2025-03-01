using Erp.Core.Features.ExpenseCategory.Commands.Models;
using Erp.Core.Features.ExpenseCategory.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ExpenseCategoryController : AppControllerBase

  {
    public ExpenseCategoryController(IWebHostEnvironment webHostEnvironment)
    {
      _webHost = webHostEnvironment;
    }




    [HttpPost(Router.ExpenseCategoryRouter.Create)]
    //[Authorize(Policy = "CreateExpenseCategory")]
    public async Task<IActionResult> CreateExpenseCategory([FromBody] AddExpenseCategoryCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }
    [HttpGet(Router.ExpenseCategoryRouter.GetList)]
    public async Task<IActionResult> GetExpenseCategoryList()
    {
      var response = await Mediator.Send(new GetExpenseCategoryListQuery());

      return Ok(response);
    }


    [HttpGet(Router.ExpenseCategoryRouter.GetById)]
    public async Task<IActionResult> GetExpenseCategoryById(int Id)
    {
      var response = await Mediator.Send(new GetExpenseCategoryByIdQuery(Id));

      return NewResult(response);
    }



    [HttpPut(Router.ExpenseCategoryRouter.Edit)]
    public async Task<IActionResult> EditExpenseCategory([FromBody] EditExpenseCategoryCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.ExpenseCategoryRouter.Delete)]
    public async Task<IActionResult> DeleteExpenseCategoryById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteExpenseCategoryCommand(Id));

      return NewResult(response);
    }
  }
}

