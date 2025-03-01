using Erp.Core.Features.EmploymentLevel.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.EmploymentLevel.Commands.Validations
{
  public class DeleteEmploymentLevelValidator : AbstractValidator<DeleteEmploymentLevelCommand>
  {
    #region
    public DeleteEmploymentLevelValidator()
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
      RuleFor(x => x.EmploymentLevelId).NotNull().WithMessage("EmploymentLevelId must not be null").NotEmpty().WithMessage("EmploymentLevelId must has value");


    }
  }
}
