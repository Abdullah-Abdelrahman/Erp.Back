using Erp.Data.Entities.SalesModule;

namespace Erp.Data.Dto.RecurringInvoice
{
  public class UpdateRecurringInvoiceRequest
  {
    public int RecurringInvoiceId { get; set; }

    public string RecurringInvoiceNumber { get; set; } = string.Empty;

    public int CustomerId { get; set; }
    public DateTime StartDate { get; set; }

    public DateTime NextInvoiceDate { get; set; }


    public int IssueEvery { get; set; } = 1;
    public Frequency Frequency { get; set; }  // Monthly, Quarterly, Yearly

    //Send me a copy of the generated invoice
    public bool sendEmail { get; set; } = false;
    //Activate automatic payment for this invoice work with strip only
    public bool automaticPayment { get; set; } = false;

    //Display "Since" and "Until" dates on invoice
    public bool DisplayRange { get; set; } = false;



    public bool IsActive { get; set; } = true;


    public decimal Tax { get; set; } = 0;
    public decimal Discount { get; set; } = 0;

    public decimal Total { get; set; }

    public List<RecurringInvoiceItemUpdateDT0> RecurringInvoiceItems { get; set; }
  }

  public class RecurringInvoiceItemUpdateDT0
  {
    public int RecurringInvoiceItemId { get; set; }
    public int RecurringInvoiceId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal discount { get; set; }
    public decimal Tax { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public string? Description { get; set; } = string.Empty;


  }
}
