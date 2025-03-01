using AutoMapper;
using Erp.Core.Features.Expense.Queries.Models;
using Erp.Data.Dto.Expense;
using Erp.Service.Abstracts.Finance;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Expense.Queries.Handlers
{
  public class ExpenseQueryHandler : ResponseHandler,
    IRequestHandler<GetExpenseByIdQuery, Response<GetExpenseByIdDto>>,
    IRequestHandler<GetExpenseListQuery, Response<List<GetExpenseByIdDto>>>
  {
    private readonly IExpenseService _ExpenseService;
    private readonly IMapper _mapper;


    public ExpenseQueryHandler(IExpenseService ExpenseService, IMapper mapper)
    {
      _ExpenseService = ExpenseService;
      _mapper = mapper;
    }



    public async Task<Response<List<GetExpenseByIdDto>>> Handle(GetExpenseListQuery request, CancellationToken cancellationToken)
    {
      var Expenses = await _ExpenseService.GetExpensesListAsync();


      return Success(Expenses);

    }

    public async Task<Response<GetExpenseByIdDto>> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
    {
      var Expense = await _ExpenseService.GetExpenseByIdAsync(request.Id);


      if (Expense == null)
      {
        return NotFound<GetExpenseByIdDto>("Expense Not Found");
      }
      else
      {

        return Success(Expense);
      }
    }
  }
}
