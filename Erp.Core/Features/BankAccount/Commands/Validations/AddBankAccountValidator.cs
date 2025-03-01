using Erp.Core.Features.BankAccount.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.BankAccount.Commands.Validations
{
  public class AddBankAccountValidator : AbstractValidator<AddBankAccountCommand>
  {
    #region
    public AddBankAccountValidator()
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


      RuleFor(x => x.AccountHolderName).NotNull().WithMessage("AccountHolderName must not be null").NotEmpty().WithMessage("AccountHolderName must has value");
    }

  }
}
