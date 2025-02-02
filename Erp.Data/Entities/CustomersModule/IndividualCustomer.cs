using Erp.Data.Dto.Customer;

namespace Erp.Data.Entities.CustomersModule
{
  public class IndividualCustomer : Customer
  {
    public IndividualCustomer(AddCustomerRequest request) : base(request)
    {
      this.FullName = request.FullName;
    }
    public IndividualCustomer(UpdateCustomerRequest request) : base(request)
    {
      this.FullName = request.FullName;
    }
    public IndividualCustomer()
    {

    }
    public string FullName { get; set; } = null!;

  }
}
