using Erp.Core.Features.Department.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.Department.Commands.Validations
{
  public class DeleteDepartmentValidator : AbstractValidator<DeleteDepartmentCommand>
  {
    #region
    public DeleteDepartmentValidator()
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
      RuleFor(x => x.DepartmentId).NotNull().WithMessage("DepartmentId must not be null").NotEmpty().WithMessage("DepartmentId must has value");


    }
  }
}
