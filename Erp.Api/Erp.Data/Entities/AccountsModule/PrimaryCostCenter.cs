namespace Erp.Data.Entities.AccountsModule
{
  public class PrimaryCostCenter : CostCenter
  {

    // Foreign key relationship
    public ICollection<CostCenter>? costCenters { get; set; } = new List<CostCenter>();
  }
}
