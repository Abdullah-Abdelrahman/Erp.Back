using Erp.Data.Dto.CreditNote;
using Erp.Data.Entities.CustomersModule;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.SalesModule
{
  //اشعار داءن
  public class CreditNote : IMustHaveTenant
  {
    [Key]
    public int CreditNoteID { get; set; }

    //[ForeignKey("Company")]
    //public int CompanyID { get; set; }
    //public Company Company { get; set; }

    public int CustomerID { get; set; }

    [ForeignKey("CustomerID")]
    public Customer Customer { get; set; }

    public DateTime CreditNoteDate { get; set; } = DateTime.Now;

    public DateTime ReleaseDate { get; set; }


    public decimal Discount { get; set; }

    public decimal Total { get; set; }

    public string? Reason { get; set; } = string.Empty;

    public ICollection<CreditNoteItem> Items { get; set; } = new List<CreditNoteItem>();

    public string TenantId { get; set; } = null!;

    public CreditNote(AddCreditNoteRequest Request)
    {
      CustomerID = Request.CustomerID;
      CreditNoteDate = Request.CreditNoteDate;
      ReleaseDate = Request.ReleaseDate;
      Reason = Request.Reason;
      Discount = Request.Discount;
      Total = Request.Total;


    }

    public CreditNote(UpdateCreditNoteRequest Request)
    {
      CreditNoteID = Request.CreditNoteId;
      CustomerID = Request.CustomerID;
      CreditNoteDate = Request.CreditNoteDate;
      ReleaseDate = Request.ReleaseDate;
      Discount = Request.Discount;
      Total = Request.Total;

    }

    public CreditNote()
    {

    }
  }
}
