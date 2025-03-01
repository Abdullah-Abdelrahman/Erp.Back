using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Expense.Commands.Models
{
  public class DeleteExpenseCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public DeleteExpenseCommand(int id)
    {
      Id = id;
    }

  }
}
