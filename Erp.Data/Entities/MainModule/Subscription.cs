namespace Erp.Data.Entities.MainModule
{
  public class Subscription
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public DateTime CreatedAt { get; set; }


    public ICollection<Module> Modules { get; set; } = new List<Module>();

  }
}
