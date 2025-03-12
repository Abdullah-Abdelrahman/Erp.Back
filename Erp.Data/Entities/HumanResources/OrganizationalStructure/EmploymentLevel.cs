using System.ComponentModel.DataAnnotations;

namespace Erp.Data.Entities.HumanResources.OrganizationalStructure
{
  //مثل موظف مبتدئ، موظف خبير، مدير فريق، مدير قسم وهكذا
  public class EmploymentLevel : IMustHaveTenant
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
