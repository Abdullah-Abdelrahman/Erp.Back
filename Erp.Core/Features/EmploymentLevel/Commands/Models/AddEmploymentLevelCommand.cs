using MediatR;
using Name.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace Erp.Core.Features.EmploymentLevel.Commands.Models
{
  public class AddEmploymentLevelCommand : IRequest<Response<string>>
  {

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

  }
}
