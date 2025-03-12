using MediatR;
using Name.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace Erp.Core.Features.Module.Commands.Models
{
  public class AddModuleCommand : IRequest<Response<string>>
  {

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    [Required]
    public bool IsActive { get; set; }
    [Required]
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public List<string> ClaimList { get; set; } = new List<string>();

  }
}
