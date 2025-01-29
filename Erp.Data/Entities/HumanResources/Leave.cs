using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.HumanResources
{
  public class Leave
  {
    [Key]
    public int LeaveID { get; set; }

    [ForeignKey("Employee")]
    public int EmployeeID { get; set; }

    [Required]
    [EnumDataType(typeof(LeaveType))]
    public LeaveType LeaveType { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    [EnumDataType(typeof(LeaveStatus))]
    public LeaveStatus Status { get; set; } = LeaveStatus.PENDING;

    public string Description { get; set; }

    // Navigation property
    public Employee Employee { get; set; }
  }

  public enum LeaveType
  {
    SICK,
    VACATION,
    MATERNITY,
    UNPAID,
    EMERGENCY
  }

  public enum LeaveStatus
  {
    PENDING,
    APPROVED,
    REJECTED
  }
}
