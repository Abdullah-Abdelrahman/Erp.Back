using Erp.Data.Entities.SalesModule;

namespace Erp.Data.Dto.Quotation
{
  public class GetQuotationByIdDto
  {
    public int QuotationId { get; set; }
    public int CustomerID { get; set; }


    public DateTime QuoteDate { get; set; } = DateTime.Now;

    public DateTime? ExpiryDate { get; set; }

    public decimal Tax { get; set; }
    public decimal Discount { get; set; }

    public decimal GrandTotal { get; set; }

    public QuotationStatus Status { get; set; } // Pending, Approved, Rejected


    public List<QuotationItemDto> QuotationItemsDto { get; set; } = new List<QuotationItemDto>();
  }

  public class QuotationItemDto
  {
    public int QuotationId { get; set; }
    public int QuotationItemId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; }
    public decimal discount { get; set; }
    public decimal Tax { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
  }

}
