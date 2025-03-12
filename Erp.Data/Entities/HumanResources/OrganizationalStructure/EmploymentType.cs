using System.ComponentModel.DataAnnotations;

namespace Erp.Data.Entities.HumanResources.OrganizationalStructure
{
  // نوع الوظيفة من حيث طبيعة الدوام، مثل دوام كامل أو جزئي أو عمل حر 
  public class EmploymentType : IMustHaveTenant
  {
    [Key]
    public int ID { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public string Description { get; set; } = string.Empty;

    [Required]
    public bool IsActive { get; set; } = true;

    public string TenantId { get; set; } = null!;

  }
}
