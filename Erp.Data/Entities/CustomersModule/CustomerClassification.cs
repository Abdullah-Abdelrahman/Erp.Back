using System.ComponentModel.DataAnnotations;

namespace Erp.Data.Entities.CustomersModule
{
  public class CustomerClassification : IMustHaveTenant
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string TenantId { get; set; } = null!;
  }
}
