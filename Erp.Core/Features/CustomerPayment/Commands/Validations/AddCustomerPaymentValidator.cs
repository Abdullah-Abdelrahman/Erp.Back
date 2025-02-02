using Erp.Core.Features.CustomerPayment.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.CustomerPayment.Commands.Validations
{
  public class AddCustomerPaymentValidator : AbstractValidator<AddCustomerPaymentCommand>
  {
    #region
    public AddCustomerPaymentValidator()
    {
      ValidationRules();
      CustomValidationRules();
    }
    #endregion
    private void CustomValidationRules()
    {

    }



    public void ValidationRules()
    {
      RuleFor(x => x.CustomerId).NotNull().WithMessage("CustomerId must not be null").NotEmpty().WithMessage("CustomerId must has value");


    }
  }
}
