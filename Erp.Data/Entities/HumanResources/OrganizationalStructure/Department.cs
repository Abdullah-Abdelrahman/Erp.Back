using Erp.Data.Entities.HumanResources.Staff;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.HumanResources.OrganizationalStructure
{
  public class Department
  {
    [Key]
    public int DepartmentID { get; set; }

    [Required]
    [MaxLength(100)]
    public string DepartmentName { get; set; } = null!;

    public string AbbreviationName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    [Required]
    public bool IsActive { get; set; } = true;

    [ForeignKey("DepartmentHead")]
    public int? DepartmentHeadID { get; set; }
    // Navigation properties
    public Employee? DepartmentHead { get; set; }
  }
}
