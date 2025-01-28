using Entitis = Erp.Data.Entities.AccountsModule;
namespace Erp.Core.Features.CostCenter.Queries.Results
{
  public class GetSecondaryCostCenterByIdResult
  {
    public int CostCenterID { get; set; }

    public string CostCenterName { get; set; } = string.Empty;

    //Primary,Secondary

    public int? ParentCostCenterID { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;


    public ICollection<Entitis.JournalEntryDetail>? journalEntryDetails { get; set; } = new List<Entitis.JournalEntryDetail>();
  }
}
