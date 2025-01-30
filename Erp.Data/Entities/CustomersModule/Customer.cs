using Erp.Data.Dto.Customer;
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


    public Customer(AddCustomerRequest request)
    {


      this.PhoneNumber = request.PhoneNumber;

      this.Landline = request.Landline;

      this.StreetAddress1 = request.StreetAddress1;

      this.StreetAddress2 = request.StreetAddress2;
      this.City = request.City;


      this.zone = request.zone;
      this.postcode = request.postcode;

      this.Country = request.Country;

      this.billingMethod = request.billingMethod;
      this.Email = request.Email;

      this.ClassificationId = request.ClassificationId;

      this.Notes = request.Notes;
      this.ContactLists = new List<ContactList>();
    }

    public Customer(UpdateCustomerRequest request)
    {
      this.CustomerId = request.CustomerId;

      this.PhoneNumber = request.PhoneNumber;

      this.Landline = request.Landline;

      this.StreetAddress1 = request.StreetAddress1;

      this.StreetAddress2 = request.StreetAddress2;
      this.City = request.City;


      this.zone = request.zone;
      this.postcode = request.postcode;

      this.Country = request.Country;

      this.billingMethod = request.billingMethod;
      this.Email = request.Email;

      this.ClassificationId = request.ClassificationId;

      this.Notes = request.Notes;

    }

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
