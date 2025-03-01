using Erp.Core.Features.Expense.Commands.Models;
using Erp.Core.Features.Expense.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ExpenseController : AppControllerBase
  {


    [HttpPost(Router.ExpenseRouter.Create)]
    //[Authorize(Policy = "CreateProduct")]
    public async Task<IActionResult> CreateExpense([FromBody] AddExpenseCommand command)
    {

      var response = await Mediator.Send(command);

      return NewResult(response);
    }

    [HttpGet(Router.ExpenseRouter.GetList)]
    public async Task<IActionResult> GetExpenseList()
    {
      var response = await Mediator.Send(new GetExpenseListQuery());

      return Ok(response);
    }


    [HttpGet(Router.ExpenseRouter.GetById)]
    public async Task<IActionResult> GetExpenseById(int Id)
    {
      var response = await Mediator.Send(new GetExpenseByIdQuery(Id));

      return NewResult(response);
    }

    [HttpPut(Router.ExpenseRouter.Edit)]
    public async Task<IActionResult> EditExpense([FromBody] EditExpenseCommand command)
    {
      var response = await Mediator.Send(command);

      return NewResult(response);
    }


    [HttpDelete(Router.ExpenseRouter.Delete)]
    public async Task<IActionResult> DeleteExpenseById([FromRoute] int Id)
    {
      var response = await Mediator.Send(new DeleteExpenseCommand(Id));

      return NewResult(response);
    }


  }
}

