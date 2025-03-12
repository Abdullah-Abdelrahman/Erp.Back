namespace Erp.Data.Entities.InventoryModule
{
  public class StockTaking : IMustHaveTenant
  {
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    public DateTime Date { get; set; }

    public ICollection<StockTakingItem> stockTakingItems { get; set; } = new List<StockTakingItem>();
    public string TenantId { get; set; } = null!;
  }
}
