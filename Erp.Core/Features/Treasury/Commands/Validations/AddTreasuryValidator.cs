using Erp.Core.Features.Treasury.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.Treasury.Commands.Validations
{
  public class AddTreasuryValidator : AbstractValidator<AddTreasuryCommand>
  {
    #region
    public AddTreasuryValidator()
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


      RuleFor(x => x.Name).NotNull().WithMessage("Name must not be null").NotEmpty().WithMessage("Name must has value");
    }

  }
}
