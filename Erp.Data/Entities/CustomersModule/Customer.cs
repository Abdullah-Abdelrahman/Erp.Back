using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.CustomersModule
{
  public class Customer
  {
    public int CustomerId { get; set; }
    public string? PhoneNumber { get; set; } = null!;
    //هاتف ارضي
    public string? Landline { get; set; } = null!;

    public string? StreetAddress1 { get; set; }

    public string? StreetAddress2 { get; set; }
    public string? City { get; set; }

    //المنطقه
    public string? zone { get; set; }
    public string? postcode { get; set; }

    public string? Country { get; set; }

    public BillingMethod billingMethod { get; set; }

    public string? Email { get; set; }

    public int? ClassificationId { get; set; }
    [ForeignKey("ClassificationId")]
    public CustomerClassification? Classification { get; set; }

    public string? Notes { get; set; }

    public ICollection<ContactList> ContactLists { get; set; } = new List<ContactList>();




  }

  public enum BillingMethod
  {
    //طباعه
    Print,
    //بريد الكتروني
    Mail
  }
  public enum CommercialOrIndividual
  {

    Commercial,
    Individual
  }
}
