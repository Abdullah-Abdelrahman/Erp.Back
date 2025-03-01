using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Erp.Data.Entities.HumanResources.Staff;

namespace Erp.Data.Entities.HumanResources
{
  public class Payroll
  {
    [Key]
    public int PayrollID { get; set; }

    [ForeignKey("Employee")]
    public int EmployeeID { get; set; }

    [Required]
    [Column(TypeName = "decimal(15, 2)")]
    public decimal Salary { get; set; }

    [Column(TypeName = "decimal(15, 2)")]
    public decimal Bonus { get; set; } = 0.00m;

    [Column(TypeName = "decimal(15, 2)")]
    public decimal Deductions { get; set; } = 0.00m;

    [NotMapped]
    public decimal NetSalary => Salary + Bonus - Deductions;  // Calculated property

    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

    [Required]
    [EnumDataType(typeof(PaymentStatus))]
    public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.PENDING;

    // Navigation properties
    public Employee Employee { get; set; }
  }

  public enum PaymentStatus
  {
    PAID,
    PENDING,
    CANCELLED
  }
}
