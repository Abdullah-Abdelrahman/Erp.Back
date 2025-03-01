using Erp.Core.Features.ExpenseCategory.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.ExpenseCategory.Queries.Models
{
  public class GetExpenseCategoryByIdQuery : IRequest<Response<GetExpenseCategoryByIdResult>>
  {
    public int Id { get; set; }

    public GetExpenseCategoryByIdQuery(int id)
    {
      Id = id;
    }
  }
}
