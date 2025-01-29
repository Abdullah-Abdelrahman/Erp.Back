using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.HumanResources
{
  public class Employee
  {
    [Key]
    public int EmployeeID { get; set; }

    [ForeignKey("Company")]
    public int CompanyID { get; set; }

    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public Gender? Gender { get; set; }  // Enum for Male, Female, Other

    [MaxLength(100)]
    public string JobTitle { get; set; }

    [ForeignKey("Department")]
    public int? DepartmentID { get; set; }

    public DateTime HireDate { get; set; } = DateTime.Now;

    public EmploymentStatus Status { get; set; } = EmploymentStatus.Active;

    [MaxLength(100)]
    public string Email { get; set; }

    [MaxLength(20)]
    public string PhoneNumber { get; set; }

    public string Address { get; set; }

    [ForeignKey("JobType")]
    public int? JobTypeID { get; set; }

    // Navigation properties
    public Company Company { get; set; }
    public Department Department { get; set; }
    public JobType JobType { get; set; }
  }

  public enum Gender
  {
    Male,
    Female,
    Other
  }

  public enum EmploymentStatus
  {
    Active,
    Inactive,
    Suspended
  }
}
