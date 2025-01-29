using System.ComponentModel.DataAnnotations;

namespace Erp.Data.Entities.CustomersModule
{
  public class CustomerClassification
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
  }
}
