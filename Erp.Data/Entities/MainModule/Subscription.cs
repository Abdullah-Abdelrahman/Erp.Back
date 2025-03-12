namespace Erp.Data.Entities.MainModule
{
  public class Subscription
  {
    public int Id { get; set; }

    public string Name { get; set; } = null!;


    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public DateTime CreatedAt { get; set; }

    public int Duration { get; set; }

    public ICollection<Company> Companies { get; set; } = new List<Company>();

    public ICollection<CompanySubscription> companySubscriptions { get; set; } = new List<CompanySubscription>();


  }
}
