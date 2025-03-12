using MediatR;
using Name.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace Erp.Core.Features.Module.Commands.Models
{
  public class EditModuleCommand : IRequest<Response<string>>
  {
    [Required]
    public int IdModuleID { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public List<string> ClaimList { get; set; } = new List<string>();

  }
}
