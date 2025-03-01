using Erp.Core.Features.EmploymentLevel.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.EmploymentLevel.Commands.Validations
{
  public class AddEmploymentLevelValidator : AbstractValidator<AddEmploymentLevelCommand>
  {
    #region
    public AddEmploymentLevelValidator()
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

