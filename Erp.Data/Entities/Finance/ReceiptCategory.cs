using System.ComponentModel.DataAnnotations;

namespace Erp.Data.Entities.Finance
{
  public class ReceiptCategory : IMustHaveTenant
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;


    ICollection<Receipt> receipts { get; set; } = new List<Receipt>();

    public string TenantId { get; set; } = null!;
  }
}
