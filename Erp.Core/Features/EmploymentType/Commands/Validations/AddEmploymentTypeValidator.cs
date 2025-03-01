using Erp.Core.Features.EmploymentType.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.EmploymentType.Commands.Validations
{
  public class AddEmploymentTypeValidator : AbstractValidator<AddEmploymentTypeCommand>
  {
    #region
    public AddEmploymentTypeValidator()
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

