using Erp.Data.Dto.Expense;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Expense.Queries.Models
{
  public class GetExpenseListQuery : IRequest<Response<List<GetExpenseByIdDto>>>
  {
  }
}
