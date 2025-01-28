using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.AccountsModule
{

  public class CostCenter
  {
    public int CostCenterId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;


    public int? ParentCostCenterID { get; set; }
    [ForeignKey("ParentCostCenterID")]
    public CostCenter? ParentCostCenter { get; set; }
  }


}
