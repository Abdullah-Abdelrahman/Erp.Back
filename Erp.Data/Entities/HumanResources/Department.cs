using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Erp.Data.Entities.MainModule;

namespace Erp.Data.Entities.HumanResources
{
  public class Department
  {
    [Key]
    public int DepartmentID { get; set; }

    [ForeignKey("Company")]
    public int CompanyID { get; set; }

    [Required]
    [MaxLength(100)]
    public string DepartmentName { get; set; }

    [ForeignKey("DepartmentHead")]
    public int? DepartmentHeadID { get; set; }  // Nullable, in case there isn't a department head assigned yet

    // Navigation properties
    public Company Company { get; set; }
    public Employee DepartmentHead { get; set; }
  }
}
