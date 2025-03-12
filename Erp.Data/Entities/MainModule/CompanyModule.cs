using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.MainModule
{
  public class CompanyModule
  {
    public int ModuleId { get; set; }
    [ForeignKey("ModuleId")]
    public Module Module { get; set; }

    public int CompanyId { get; set; }
    [ForeignKey("CompanyId")]
    public Company Company { get; set; }

    public bool IsActive { get; set; }
  }
}
