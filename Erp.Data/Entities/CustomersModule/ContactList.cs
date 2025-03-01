using Erp.Data.Dto.Customer;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Erp.Data.Entities.CustomersModule
{
  //قاءمه اتصال
  public class ContactList : IMustHaveTenant
  {

    public int ContactListId { get; set; }
    public string? FirstName { get; set; } = null!;

    public string? LastName { get; set; } = null!;

    public string? PhoneNumber { get; set; } = null!;
    //هاتف ارضي
    public string? Landline { get; set; } = null!;


    public string? Email { get; set; }

    public int CustomerId { get; set; }
    [JsonIgnore]
    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; }
    public string TenantId { get; set; } = null!;

    public ContactList(AddContactListDT0 addContactListDT0, int customerId)
    {
      this.FirstName = addContactListDT0.FirstName;
      this.LastName = addContactListDT0.LastName;
      this.PhoneNumber = addContactListDT0.PhoneNumber;
      this.Landline = addContactListDT0.Landline;
      this.Email = addContactListDT0.Email;
      this.CustomerId = customerId;
    }
    public ContactList(UpdateContactListDT0 UpdateContactListDT0)
    {
      this.ContactListId = UpdateContactListDT0.ContactListId;
      this.FirstName = UpdateContactListDT0.FirstName;
      this.LastName = UpdateContactListDT0.LastName;
      this.PhoneNumber = UpdateContactListDT0.PhoneNumber;
      this.Landline = UpdateContactListDT0.Landline;
      this.Email = UpdateContactListDT0.Email;
      this.CustomerId = UpdateContactListDT0.CustomerId;
    }
    public ContactList()
    {

    }

  }
}
