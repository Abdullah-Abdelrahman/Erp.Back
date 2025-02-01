using Erp.Data.Entities.SalesModule;

namespace Erp.Data.Dto.Invoice
{
  public class GetInvoiceByIdDto
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



    public List<InvoiceItemDto> InvoiceItemsDto { get; set; } = new List<InvoiceItemDto>();
  }

  public class InvoiceItemDto
  {
    public int InvoiceId { get; set; }
    public int InvoiceItemId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; }
    public decimal discount { get; set; }
    public decimal Tax { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
  }

}
