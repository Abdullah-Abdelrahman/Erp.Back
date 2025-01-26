using System.ComponentModel.DataAnnotations;

namespace Erp.Data.Entities
{
  public class JobType
  {
    [Key]
    public int JobTypeID { get; set; }

    [Required]
    [MaxLength(100)]
    public string JobTypeName { get; set; }  // Example: 'Full-Time', 'Part-Time', 'Contract', 'Internship'

    public string Description { get; set; }
  }
}
