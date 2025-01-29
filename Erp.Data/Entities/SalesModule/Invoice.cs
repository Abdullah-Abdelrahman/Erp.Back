using Erp.Data.Entities.CustomersModule;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.SalesModule
{
  public class Invoice
  {
    [Key]
    public int InvoiceID { get; set; }

    //[ForeignKey("Company")]
    //public int CompanyID { get; set; }
    //public Company Company { get; set; }

    public int CustomerID { get; set; }

    [ForeignKey("CustomerID")]
    public Customer Customer { get; set; }

    public DateTime InvoiceDate { get; set; } = DateTime.Now;

    public DateTime ReleaseDate { get; set; }
    //عدد الايام لتصبح الفاتوره مستحقه الدفع
    public int PaymentTerms { get; set; } = 0;

    public decimal Tax { get; set; }
    public decimal Discount { get; set; }

    public decimal Total { get; set; }

    public InvoiceStatus Status { get; set; } = InvoiceStatus.Draft;

    public ICollection<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
  }

  public enum InvoiceStatus
  {
    Draft,
    Paid,
    Return,
    NotPaid,
    Overdue
  }
}
