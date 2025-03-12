using Erp.Core.Features.Employee.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.Employee.Commands.Validations
{
  public class AddEmployeeValidator : AbstractValidator<AddEmployeeCommand>
  {
    #region
    public AddEmployeeValidator()
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
      RuleFor(x => x.FirstName).NotNull().WithMessage("Name must not be null").NotEmpty().WithMessage("Name must has value");

      RuleFor(x => x.LastName).NotNull().WithMessage("LastName must not be null");

      RuleFor(x => x.RoleID).NotNull().WithMessage("RoleID must not be null").NotEmpty().WithMessage("RoleID must has value");

      RuleFor(x => x.HireDate).NotNull().WithMessage("HireDate must not be null").NotEmpty().WithMessage("HireDate must has value");

      RuleFor(x => x.DateOfBirth).NotNull().WithMessage("DateOfBirth must not be null").NotEmpty().WithMessage("DateOfBirth must has value");

      RuleFor(x => x.Status).NotNull().WithMessage("Status must not be null");

      RuleFor(x => x.Email).NotNull().WithMessage("Email must not be null").NotEmpty().WithMessage("Email must has value");
    }
  }
}

