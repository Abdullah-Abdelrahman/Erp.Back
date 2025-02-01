namespace Erp.Data.Dto.Quotation
{
  public class AddQuotationRequest
  {
    public int CustomerID { get; set; }


    public DateTime QuoteDate { get; set; } = DateTime.Now;

    public DateTime? ExpiryDate { get; set; }

    public decimal Tax { get; set; }
    public decimal Discount { get; set; }

    public decimal GrandTotal { get; set; }


    public List<QuotationItemDT0> QuotationItemDT0s { get; set; } = new List<QuotationItemDT0>();
  }


  public class QuotationItemDT0
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
