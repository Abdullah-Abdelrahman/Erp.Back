using MediatR;
using Name.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace Erp.Core.Features.ExpenseCategory.Commands.Models
{
  public class EditExpenseCategoryCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

  }
}
