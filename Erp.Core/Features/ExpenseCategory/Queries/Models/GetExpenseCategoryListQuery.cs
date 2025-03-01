using Erp.Core.Features.ExpenseCategory.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.ExpenseCategory.Queries.Models
{
  public class GetExpenseCategoryListQuery : IRequest<Response<List<GetExpenseCategoryByIdResult>>>
  {
  }
}
