using Erp.Core.Features.Department.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.Department.Commands.Validations
{
  public class AddDepartmentValidator : AbstractValidator<AddDepartmentCommand>
  {
    #region
    public AddDepartmentValidator()
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

