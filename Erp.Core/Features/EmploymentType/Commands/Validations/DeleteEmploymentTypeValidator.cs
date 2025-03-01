using Erp.Core.Features.EmploymentType.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.EmploymentType.Commands.Validations
{
  public class DeleteEmploymentTypeValidator : AbstractValidator<DeleteEmploymentTypeCommand>
  {
    #region
    public DeleteEmploymentTypeValidator()
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
      RuleFor(x => x.EmploymentTypeId).NotNull().WithMessage("EmploymentTypeId must not be null").NotEmpty().WithMessage("EmploymentTypeId must has value");


    }
  }
}
