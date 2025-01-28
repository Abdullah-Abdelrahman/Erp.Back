using Entitis = Erp.Data.Entities.AccountsModule;

namespace Erp.Core.Features.CostCenter.Queries.Results
{
  public class GetPrimaryCostCenterByIdResult
  {
    public int CostCenterID { get; set; }

    public string CostCenterName { get; set; } = string.Empty;


    public int? ParentCostCenterID { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;


    public ICollection<Entitis.CostCenter>? ChildCostCenters { get; set; } = new List<Entitis.CostCenter>();


  }
}
