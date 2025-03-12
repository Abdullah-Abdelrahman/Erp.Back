using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.MainModule
{
  public class CompanySubscription
  {
    public int Id { get; set; }

    public int CompanyId { get; set; }
    [ForeignKey("CompanyId")]
    public Company Company { get; set; }

    public int SubscriptionId { get; set; }

    [ForeignKey("SubscriptionId")]
    public Subscription Subscription { get; set; }
    public DateTime EndDate { get; set; }
  }
}
