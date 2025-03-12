using System.ComponentModel.DataAnnotations;

namespace Erp.Data.Entities.MainModule
{


  public class Company : IMustHaveTenant
  {
    public int CompanyID { get; set; }

    public string CompanyName { get; set; } = string.Empty;

    public string? CompanyAddress { get; set; } = string.Empty;
    [Required]
    public string CompanyEmail { get; set; } = null!;

    public string? Domain { get; set; }

    [Required]
    public string Password { get; set; } = null!;
    public string TenantId { get; set; } = null!;

    public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();

    public ICollection<CompanySubscription> companySubscriptions { get; set; } = new List<CompanySubscription>();



    public ICollection<CompanyModule> companyModules { get; set; } = new List<CompanyModule>();
  }

}
