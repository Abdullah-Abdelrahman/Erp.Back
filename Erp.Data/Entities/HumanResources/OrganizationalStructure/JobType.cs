using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.HumanResources.OrganizationalStructure
{
  //مثل محاسب، مسئول شبكات، فني. وحدد له وصفًا تعريفيًا بالأدوار والمسئوليات
  //المسمي الوظيفي
  public class JobType : IMustHaveTenant
  {
    [Key]
    public int ID { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public string Description { get; set; } = string.Empty;

    [Required]
    public bool IsActive { get; set; } = true;

    public int? DepartmentId { get; set; }
    [ForeignKey("DepartmentId")]
    public Department? Department { get; set; }

    public string TenantId { get; set; } = null!;
  }
}
