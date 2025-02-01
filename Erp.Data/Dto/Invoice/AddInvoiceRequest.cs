using Erp.Data.Entities.SalesModule;

namespace Erp.Data.Dto.Invoice
{
  public class AddInvoiceRequest
  {
    public int CustomerID { get; set; }


    public DateTime InvoiceDate { get; set; } = DateTime.Now;

    public DateTime ReleaseDate { get; set; } = DateTime.Now;
    //عدد الايام لتصبح الفاتوره مستحقه الدفع
    public int PaymentTerms { get; set; } = 0;

    public decimal Tax { get; set; }
    public decimal Discount { get; set; }

    public decimal Total { get; set; }

    public InvoiceStatus Status { get; set; } = InvoiceStatus.Draft;


    public List<InvoiceItemDT0> InvoiceItemDT0s { get; set; } = new List<InvoiceItemDT0>();
  }


  public class InvoiceItemDT0
  {

    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; }
    public decimal discount { get; set; }
    public decimal Tax { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }

  }
}
