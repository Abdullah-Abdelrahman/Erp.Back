using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities
{
  public class Vendor
  {
    [Key]
    public int VendorID { get; set; }

    [ForeignKey("Company")]
    public int CompanyID { get; set; }

    [Required]
    [StringLength(100)]
    public string VendorName { get; set; }

    [StringLength(100)]
    public string ContactName { get; set; }

    [StringLength(100)]
    [EmailAddress]
    public string ContactEmail { get; set; }

    [StringLength(20)]
    public string ContactPhone { get; set; }

    public string Address { get; set; }

    [Required]
    [EnumDataType(typeof(VendorStatus))]
    public VendorStatus Status { get; set; } = VendorStatus.ACTIVE;

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    // Navigation property
    public Company Company { get; set; }
  }

  public enum VendorStatus
  {
    ACTIVE,
    INACTIVE,
    SUSPENDED
  }
}
