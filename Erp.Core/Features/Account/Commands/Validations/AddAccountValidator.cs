using Erp.Core.Features.Account.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.Account.Commands.Validations
{
  public class AddAccountValidator : AbstractValidator<AddAccountCommand>
  {
    #region
    public AddAccountValidator()
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
      RuleFor(x => x.AccountName).NotNull().WithMessage("Name must not be null").NotEmpty().WithMessage("Name must has value");


    }
  }
}
