using Erp.Data.Entities.CustomersModule;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.SalesModule
{
  public class RecurringInvoice
  {
    [Key]
    public int Id { get; set; }

    //الاشتراك خانه
    [Required]
    public string RecurringInvoiceNumber { get; set; } = string.Empty;

    [Required]
    public int CustomerId { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public Customer Customer { get; set; } = null!;

    [Required]
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


    public decimal Tax { get; set; }
    public decimal Discount { get; set; }

    public decimal Total { get; set; }

  }

  public enum Frequency
  {
    Monthly, Quarterly, Yearly
  }
}
