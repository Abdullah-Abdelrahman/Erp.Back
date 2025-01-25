using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities
{
  public class BankAccount
  {
    [Key]
    public int BankAccountID { get; set; }

    [Required]
    public int CompanyID { get; set; }

    [ForeignKey(nameof(CompanyID))]
    public Company Company { get; set; }

    [Required]
    [MaxLength(100)]
    public string AccountHolderName { get; set; }

    [Required]
    [MaxLength(100)]
    public string BankName { get; set; }

    [Required]
    [MaxLength(50)]
    public string AccountNumber { get; set; }

    [MaxLength(34)]
    public string IBAN { get; set; }

    [MaxLength(11)]
    public string SWIFTCode { get; set; }

    [MaxLength(3)]
    public string CurrencyCode { get; set; } = "USD";

    public decimal Balance { get; set; } = 0.00m;

    public AccountStatus Status { get; set; } = AccountStatus.ACTIVE;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
  }

  public enum AccountStatus
  {
    ACTIVE,
    INACTIVE,
    CLOSED
  }
}
