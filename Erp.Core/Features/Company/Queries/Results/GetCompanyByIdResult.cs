namespace Erp.Core.Features.Company.Queries.Results
{
  public class GetCompanyByIdResult
  {
    public int CompanyID { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? CompanyAddress { get; set; }

    public string CompanyEmail { get; set; } = null!;

    public string? Domain { get; set; }


    public string Password { get; set; } = null!;
    public string TenantId { get; set; } = null!;

  }
}
