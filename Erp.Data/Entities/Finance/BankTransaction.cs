using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.Finance
{
  public class BankTransaction
  {
    [Key]
    public int BankTransactionID { get; set; }

    [Required]
    public int BankAccountID { get; set; }

    [ForeignKey(nameof(BankAccountID))]
    public BankAccount BankAccount { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

    [Required]
    public TransactionType TransactionType { get; set; }

    [Required]
    public decimal Amount { get; set; }

    [MaxLength(50)]
    public string ReferenceNumber { get; set; }

    public string Description { get; set; }

    public TransactionStatus Status { get; set; } = TransactionStatus.PENDING;
  }



  public enum TransactionStatus
  {
    PENDING,
    COMPLETED,
    FAILED
  }
}
