using System.ComponentModel.DataAnnotations;

namespace Erp.Data.Entities.Finance
{
  public class ExpenseCategory : IMustHaveTenant
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    public string TenantId { get; set; } = null!;

  }
}
