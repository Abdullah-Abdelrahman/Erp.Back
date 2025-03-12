using Erp.Data.Entities.Finance;
using Erp.Data.Entities.HumanResources.OrganizationalStructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Erp.Data.Entities.HumanResources.Staff
{
  public class Employee : IMustHaveTenant
  {
    [Key]
    public int EmployeeID { get; set; }



    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = null!;


    [MaxLength(100)]
    public string LastName { get; set; } = null!;

    public string Notes { get; set; } = string.Empty;
    public string? ImagePath { get; set; }

    [NotMapped]
    public byte[]? ImageFile { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public EmploymentStatus Status { get; set; } = EmploymentStatus.Active;


    public string RoleID { get; set; }

    //-- Personal information --
    [Required]
    public DateTime DateOfBirth { get; set; }

    public Gender? Gender { get; set; }  // Enum for Male, Female
    [Required]
    public string Country { get; set; } = string.Empty;

    // -- Contact information --
    [MaxLength(20)]
    public string? PhoneNumber { get; set; }

    public string? Landline { get; set; }
    [EmailAddress]
    public string? PrivateEmail { get; set; }

    // -- Location --

    public string? Address1 { get; set; } = string.Empty;
    public string? Address2 { get; set; } = string.Empty;
    public string? City { get; set; } = string.Empty;
    //المنطقه
    public string? zone { get; set; } = string.Empty;
    public string? postcode { get; set; } = string.Empty;


    // -- Job Information --

    //المسمي الوظيفي
    public int? JobTypeID { get; set; }

    [ForeignKey("Department")]
    public int? DepartmentID { get; set; }

    [Required]
    public DateTime HireDate { get; set; } = DateTime.Now;

    public int? EmploymentLevelId { get; set; }

    public int? EmploymentTypeId { get; set; }

    public int? DirectManagerId { get; set; }


    public bool UseDefaultFinancialHistory { get; set; } = true;

    // Navigation properties


    [ForeignKey("RoleID")]
    public ApplicationRole Role { get; set; }

    public Department? Department { get; set; }
    public JobType? JobType { get; set; }
    [ForeignKey("EmploymentLevelId")]
    public EmploymentLevel? EmploymentLevel { get; set; }

    [ForeignKey("EmploymentTypeId")]
    public EmploymentType? EmploymentType { get; set; }

    [ForeignKey("DirectManagerId")]
    public Employee? DirectManager { get; set; }



    [JsonIgnore]
    public ICollection<BankAccount> BankAccountDepositPermessions { get; set; } = new List<BankAccount>();
    [JsonIgnore]
    public ICollection<BankAccount> BankAccountWithdrawPermessions { get; set; } = new List<BankAccount>();
    [JsonIgnore]
    public ICollection<Treasury> TreasuryDepositPermessions { get; set; } = new List<Treasury>();

    [JsonIgnore]
    public ICollection<Treasury> TreasuryWithdrawPermessions { get; set; } = new List<Treasury>();
    public string TenantId { get; set; } = null!;
  }

  public enum Gender
  {
    Male,
    Female
  }

  public enum EmploymentStatus
  {
    Active,
    Inactive,
    Suspended
  }
}
