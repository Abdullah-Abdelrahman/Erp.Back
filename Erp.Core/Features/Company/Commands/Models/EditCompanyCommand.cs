using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Company.Commands.Models
{
  public class EditCompanyCommand : IRequest<Response<string>>
  {
    public int CompanyId { get; set; }
    public string CompanyName { get; set; } = string.Empty;

    public string? CompanyAddress { get; set; } = string.Empty;

    public string CompanyEmail { get; set; } = null!;

    public string? Domain { get; set; }


    public string Password { get; set; } = null!;
  }
}
