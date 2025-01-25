using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities
{
  public class Invoice
  {
    [Key]
    public int InvoiceID { get; set; }

    [ForeignKey("Company")]
    public int CompanyID { get; set; }
    public Company Company { get; set; }

    [ForeignKey("Customer")]
    public int CustomerID { get; set; }
    //public Customer Customer { get; set; }

    public DateTime InvoiceDate { get; set; } = DateTime.Now;

    public DateTime DueDate { get; set; }

    [Column(TypeName = "decimal(15, 2)")]
    public decimal TotalAmount { get; set; }

    public InvoiceStatus Status { get; set; } = InvoiceStatus.Draft;
  }

  public enum InvoiceStatus
  {
    Draft,
    Paid,
    Overdue
  }
}
