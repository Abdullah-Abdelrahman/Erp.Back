using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.ExpenseCategory.Commands.Models
{
  public class DeleteExpenseCategoryCommand : IRequest<Response<string>>
  {
    public int ExpenseCategoryId { get; set; }

    public DeleteExpenseCategoryCommand(int id)
    {
      ExpenseCategoryId = id;
    }
  }
}
