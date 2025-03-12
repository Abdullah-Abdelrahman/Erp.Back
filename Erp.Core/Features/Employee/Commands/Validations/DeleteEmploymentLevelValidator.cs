using Erp.Core.Features.Employee.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.Employee.Commands.Validations
{
  public class DeleteEmployeeValidator : AbstractValidator<DeleteEmployeeCommand>
  {
    #region
    public DeleteEmployeeValidator()
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
      RuleFor(x => x.EmployeeId).NotNull().WithMessage("EmployeeId must not be null").NotEmpty().WithMessage("EmployeeId must has value");


    }
  }
}
