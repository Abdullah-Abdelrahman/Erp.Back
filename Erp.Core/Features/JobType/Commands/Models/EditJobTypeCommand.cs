using MediatR;
using Name.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace Erp.Core.Features.JobType.Commands.Models
{
  public class EditJobTypeCommand : IRequest<Response<string>>
  {
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;


    public int? DepartmentId { get; set; }


    [Required]
    public bool IsActive { get; set; } = true;


  }
}
