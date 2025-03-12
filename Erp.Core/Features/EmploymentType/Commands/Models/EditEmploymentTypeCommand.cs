using MediatR;
using Name.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace Erp.Core.Features.EmploymentType.Commands.Models
{
  public class EditEmploymentTypeCommand : IRequest<Response<string>>
  {

    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    [Required]
    public bool IsActive { get; set; } = true;

  }
}
