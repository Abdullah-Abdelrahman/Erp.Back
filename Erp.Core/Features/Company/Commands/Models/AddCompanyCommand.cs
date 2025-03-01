using MediatR;
using Name.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace Erp.Core.Features.Company.Commands.Models
{
  public class AddCompanyCommand : IRequest<Response<string>>
  {
    [Required]
    public string CompanyName { get; set; } = string.Empty;

    public string? CompanyAddress { get; set; } = string.Empty;
    [Required]
    public string CompanyEmail { get; set; } = null!;

    public string? Domain { get; set; }

    [Required]
    public string Password { get; set; } = null!;

  }
}
