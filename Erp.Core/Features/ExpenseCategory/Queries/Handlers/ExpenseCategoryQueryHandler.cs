using AutoMapper;
using Erp.Core.Features.ExpenseCategory.Queries.Models;
using Erp.Core.Features.ExpenseCategory.Queries.Results;
using Erp.Service.Abstracts.Finance;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.ExpenseCategory.Queries.Handlers
{
  public class ExpenseCategoryQueryHandler : ResponseHandler, IRequestHandler<GetExpenseCategoryByIdQuery, Response<GetExpenseCategoryByIdResult>>, IRequestHandler<GetExpenseCategoryListQuery, Response<List<GetExpenseCategoryByIdResult>>>
  {
    #region Fields
    private readonly IExpenseCategoryService _ExpenseCategoryService;
    private readonly IMapper _mapper;
    #endregion
    public ExpenseCategoryQueryHandler(IExpenseCategoryService ExpenseCategoryService, IMapper mapper)
    {
      _mapper = mapper;
      _ExpenseCategoryService = ExpenseCategoryService;
    }

    public async Task<Response<GetExpenseCategoryByIdResult>> Handle(GetExpenseCategoryByIdQuery request, CancellationToken cancellationToken)
    {
      var ExpenseCategory = await _ExpenseCategoryService.GetExpenseCategoryByIdAsync(request.Id);


      if (ExpenseCategory == null)
      {
        return NotFound<GetExpenseCategoryByIdResult>("ExpenseCategory Not Found");
      }
      else
      {
        var ExpenseCategoryMapper = _mapper.Map<GetExpenseCategoryByIdResult>(ExpenseCategory);
        return Success(ExpenseCategoryMapper);
      }
    }

    public async Task<Response<List<GetExpenseCategoryByIdResult>>> Handle(GetExpenseCategoryListQuery request, CancellationToken cancellationToken)
    {
      var ExpenseCategoryList = await _ExpenseCategoryService.GetExpenseCategorysListAsync();

      var ExpenseCategoryListMapper = _mapper.Map<List<GetExpenseCategoryByIdResult>>(ExpenseCategoryList);

      return Success(ExpenseCategoryListMapper);
    }
  }
}
