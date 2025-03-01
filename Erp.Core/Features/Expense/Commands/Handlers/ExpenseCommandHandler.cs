using AutoMapper;
using Erp.Core.Features.Expense.Commands.Models;
using Erp.Data.Dto.Expense;
using Erp.Data.MetaData;
using Erp.Service.Abstracts.Finance;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Expense.Commands.Handlers
{
  public class ExpenseCommandHandler : ResponseHandler,
    IRequestHandler<AddExpenseCommand, Response<string>>,
    IRequestHandler<EditExpenseCommand, Response<string>>,
  IRequestHandler<DeleteExpenseCommand, Response<string>>


  {

    private readonly IExpenseService _ExpenseService;
    private readonly IMapper _mapper;

    public ExpenseCommandHandler(IExpenseService ExpenseService, IMapper mapper)
    {
      _ExpenseService = ExpenseService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddExpenseCommand request, CancellationToken cancellationToken)
    {
      var AddExpenseRequestMapper = _mapper.Map<AddExpenseRequest>(request);
      var result = await _ExpenseService.AddExpense(AddExpenseRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Added successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened :" + result);
      }
    }

    public async Task<Response<string>> Handle(EditExpenseCommand request, CancellationToken cancellationToken)
    {

      var EditExpenseRequestMapper = _mapper.Map<UpdateExpenseRequest>(request);
      var result = await _ExpenseService.UpdateAsync(EditExpenseRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }


    }

    public async Task<Response<string>> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
    {


      var result = await _ExpenseService.DeleteByIdAsync(request.Id);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Deleted<string>();
      }
      else
      {
        return BadRequest<string>(result);
      }




    }



  }
}
