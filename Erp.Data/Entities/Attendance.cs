using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Name.Data.Entities
{
    public class Attendance
    {
        [Key]
        public int AttendanceID { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        public DateTime? ClockInTime { get; set; }

        public DateTime? ClockOutTime { get; set; }

        [Required]
        [EnumDataType(typeof(AttendanceStatus))]
        public AttendanceStatus Status { get; set; } = AttendanceStatus.PRESENT;

        [Required]
        public DateTime Date { get; set; } = DateTime.UtcNow.Date;

        // Navigation property
        public Employee Employee { get; set; }
    }

    public enum AttendanceStatus
    {
        PRESENT,
        ABSENT,
        LEAVE,
        LATE
    }
}
