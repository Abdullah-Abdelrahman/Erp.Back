using Erp.Data.Dto.Expense;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Expense.Commands.Models
{
  public class EditExpenseCommand : UpdateExpenseRequest, IRequest<Response<string>>
  {


  }
}
