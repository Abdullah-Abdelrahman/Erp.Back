using Erp.Data.Entities.SalesModule;

namespace Erp.Data.Dto.Invoice
{
  public class UpdateInvoiceRequest
  {
    public int InvoiceId { get; set; }
    public int CustomerID { get; set; }


    public DateTime InvoiceDate { get; set; } = DateTime.Now;

    public DateTime ReleaseDate { get; set; } = DateTime.Now;
    //عدد الايام لتصبح الفاتوره مستحقه الدفع
    public int PaymentTerms { get; set; } = 0;

    public decimal Tax { get; set; }
    public decimal Discount { get; set; }

    public decimal Total { get; set; }

    public InvoiceStatus Status { get; set; } = InvoiceStatus.Draft;


    public List<InvoiceItemUpdateDT0> InvoiceItems { get; set; }
  }

  public class InvoiceItemUpdateDT0
  {
    public int InvoiceItemId { get; set; }
    public int InvoiceId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal discount { get; set; }
    public decimal Tax { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public string? Description { get; set; } = string.Empty;


  }
}
