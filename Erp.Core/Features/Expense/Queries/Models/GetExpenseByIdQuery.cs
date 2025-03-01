using Erp.Data.Dto.Expense;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Expense.Queries.Models
{
  public class GetExpenseByIdQuery : IRequest<Response<GetExpenseByIdDto>>
  {
    public int Id { get; set; }

    public GetExpenseByIdQuery(int id)
    {
      Id = id;
    }
  }
}
