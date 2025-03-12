using MediatR;
using Name.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace Erp.Core.Features.Department.Commands.Models
{
  public class AddDepartmentCommand : IRequest<Response<string>>
  {

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    [Required]
    public bool IsActive { get; set; } = true;


    public int? DepartmentHeadID { get; set; }
  }
}
