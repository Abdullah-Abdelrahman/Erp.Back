using Erp.Core.Features.Customer.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.Customer.Commands.Validations
{
  public class AddCustomerValidator : AbstractValidator<AddCustomerCommand>
  {
    #region
    public AddCustomerValidator()
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
      //RuleFor(x => x.n).NotNull().WithMessage("Name must not be null").NotEmpty().WithMessage("Name must has value");


    }
  }
}
